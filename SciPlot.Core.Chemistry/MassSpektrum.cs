using SciPlot.Core.Charts.Chemistry.ZoomStrategies;
using SkiaSharp;

namespace SciPlot.Core.Chemistry;

public class MassSpectrumChart : PlotBase
{
    public MassSpectrumChart()
    {
        ZoomStrategy = new MassSpectrumZoomStrategy();
    }

    public override void Draw(SKCanvas canvas, SKRect bounds)
    {
        const float padding = 40;
        PlotBounds = new SKRect(bounds.Left + padding, bounds.Top + padding,
                                bounds.Right - padding, bounds.Bottom - padding);

        if (DataSource == null || !DataSource.Series.Any()) return;

        using var paint = new SKPaint();

        // Achsen zeichnen
        DrawAxes(canvas, bounds, paint);

        // Daten zeichnen
        foreach (var series in DataSource.Series)
        {
            paint.Color = series.Color;
            paint.StrokeWidth = 2;
            paint.Style = SKPaintStyle.Fill;
            var points = series.Points.Cast<IDataPoint>().ToList();
            for (int i = 0; i < points.Count; i++)
            {
                var point = points[i];
                var screenPoint = ConvertDataToScreenPoint(point);
                // Zeichne einen vertikalen Balken für jeden Datenpunkt
                var barRect = new SKRect(
                    screenPoint.X - 0.5f,
                    screenPoint.Y,
                    screenPoint.X + 0.5f,
                    PlotBounds.Bottom  // Ändern Sie dies von bounds.Bottom zu PlotBounds.Bottom
                );
                canvas.DrawRect(barRect, paint);
            }
        }

        DrawAxisLabels(canvas, bounds, paint);

        // Beschriftungen zeichnen
        DrawLabels(canvas, bounds, paint);
    }

    private void DrawAxes(SKCanvas canvas, SKRect bounds, SKPaint paint)
    {
        paint.Color = SKColors.Black;
        paint.StrokeWidth = 2;
        paint.Style = SKPaintStyle.Stroke;

        // X-Achse
        canvas.DrawLine(PlotBounds.Left, PlotBounds.Bottom, PlotBounds.Right, PlotBounds.Bottom, paint);

        // Y-Achse
        canvas.DrawLine(PlotBounds.Left, PlotBounds.Top, PlotBounds.Left, PlotBounds.Bottom, paint);
    }

    private void DrawAxisLabels(SKCanvas canvas, SKRect bounds, SKPaint paint)
    {
        paint.TextSize = 10;
        paint.Style = SKPaintStyle.Fill;

        // X-Achsen-Markierungen
        for (int i = 0; i <= 5; i++)
        {
            float x = PlotBounds.Left + (i * PlotBounds.Width / 5);
            float value = (float)(DataSource.XMin + (i * (DataSource.XMax - DataSource.XMin) / 5));
            canvas.DrawLine(x, PlotBounds.Bottom, x, PlotBounds.Bottom + 5, paint);
            canvas.DrawText(value.ToString("F1"), x, PlotBounds.Bottom + 15, paint);
        }

        // Y-Achsen-Markierungen
        for (int i = 0; i <= 5; i++)
        {
            float y = PlotBounds.Bottom - (i * PlotBounds.Height / 5);
            float value = (float)(DataSource.YMin + (i * (DataSource.YMax - DataSource.YMin) / 5));
            canvas.DrawLine(PlotBounds.Left - 5, y, PlotBounds.Left, y, paint);
            canvas.DrawText(value.ToString("F0"), PlotBounds.Left - 35, y + 5, paint);
        }
    }

    private void DrawLabels(SKCanvas canvas, SKRect bounds, SKPaint paint)
    {
        paint.Color = SKColors.Black;
        paint.TextSize = 12;
        paint.Style = SKPaintStyle.Fill;

        // X-Achsen-Beschriftung
        if (!string.IsNullOrEmpty(DataSource?.XAxisLabel))
        {
            canvas.DrawText(DataSource.XAxisLabel, PlotBounds.MidX, bounds.Bottom - 10, paint);
        }

        // Y-Achsen-Beschriftung
        if (!string.IsNullOrEmpty(DataSource?.YAxisLabel))
        {
            canvas.Save();
            canvas.RotateDegrees(-90);
            canvas.DrawText(DataSource.YAxisLabel, -PlotBounds.MidY, bounds.Left + 20, paint);
            canvas.Restore();
        }

        // Titel
        if (!string.IsNullOrEmpty(Title))
        {
            paint.TextSize = 16;
            canvas.DrawText(Title, PlotBounds.MidX, bounds.Top + 20, paint);
        }
    }

    protected override SKPoint ConvertDataToScreenPoint(IDataPoint dataPoint)
    {
        double xRange = DataSource.XMax.Value - DataSource.XMin.Value;
        double yRange = DataSource.YMax.Value - DataSource.YMin.Value;

        if (xRange == 0 || yRange == 0)
        {
            return new SKPoint(PlotBounds.Left, PlotBounds.Bottom);
        }

        float x = (float)((dataPoint.X - DataSource.XMin.Value) / xRange * PlotBounds.Width + PlotBounds.Left);
        float y = (float)(PlotBounds.Bottom - (dataPoint.Y - DataSource.YMin.Value) / yRange * PlotBounds.Height);
        return new SKPoint(x, y);
    }
}
