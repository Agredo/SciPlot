using SciPlot.Core.Charts.ZoomStratagies;
using SkiaSharp;
using System.Runtime.CompilerServices;

namespace SciPlot.Core.Charts;

public class LineChart : PlotBase
{
    public LineChart()
    {
        ZoomStrategy = new CenteredZoomStrategy();
    }

    public override void Draw(SKCanvas canvas, SKRect bounds)
    {
        PlotBounds = bounds;
        if (DataSource == null || !DataSource.Series.Any()) return;

        using var paint = new SKPaint();

        // Achsen zeichnen
        DrawAxes(canvas, bounds, paint);

        // Daten zeichnen
        foreach (var series in DataSource.Series)
        {
            paint.Color = series.Color;
            paint.StrokeWidth = 2;
            paint.Style = SKPaintStyle.Stroke;

            var path = new SKPath();
            var points = series.Points.Cast<IDataPoint>().ToList();

            if (points.Any())
            {
                var firstPoint = ConvertDataToScreenPoint(points[0]);
                path.MoveTo(firstPoint);

                for (int i = 1; i < points.Count; i++)
                {
                    var point = ConvertDataToScreenPoint(points[i]);
                    path.LineTo(point);
                }
            }

            canvas.DrawPath(path, paint);
        }

        // Beschriftungen zeichnen
        DrawLabels(canvas, bounds, paint);
    }

    private void DrawAxes(SKCanvas canvas, SKRect bounds, SKPaint paint)
    {
        paint.Color = SKColors.Black;
        paint.StrokeWidth = 1;
        paint.Style = SKPaintStyle.Stroke;

        // X-Achse
        canvas.DrawLine(bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom, paint);

        // Y-Achse
        canvas.DrawLine(bounds.Left, bounds.Top, bounds.Left, bounds.Bottom, paint);

        // Zeichne Achsenmarkierungen
        DrawAxisTicks(canvas, bounds, paint);
    }

    private void DrawAxisTicks(SKCanvas canvas, SKRect bounds, SKPaint paint)
    {
        paint.TextSize = 10;
        paint.Style = SKPaintStyle.Fill;

        // X-Achsen-Markierungen
        int xTickCount = 5;
        for (int i = 0; i <= xTickCount; i++)
        {
            float x = bounds.Left + (i * bounds.Width / xTickCount);
            canvas.DrawLine(x, bounds.Bottom, x, bounds.Bottom + 5, paint);
            double value = DataSource.XMin.Value + (i * (DataSource.XMax.Value - DataSource.XMin.Value) / xTickCount);
            canvas.DrawText($"{value:F1}", x, bounds.Bottom + 15, paint);
        }

        // Y-Achsen-Markierungen
        int yTickCount = 5;
        for (int i = 0; i <= yTickCount; i++)
        {
            float y = bounds.Bottom - (i * bounds.Height / yTickCount);
            canvas.DrawLine(bounds.Left - 5, y, bounds.Left, y, paint);
            double value = DataSource.YMin.Value + (i * (DataSource.YMax.Value - DataSource.YMin.Value) / yTickCount);
            canvas.DrawText($"{value:F1}", bounds.Left - 35, y + 5, paint);
        }
    }

    private void DrawLabels(SKCanvas canvas, SKRect bounds, SKPaint paint)
    {
        paint.Color = SKColors.Black;
        paint.TextSize = 12;
        paint.Style = SKPaintStyle.Fill;

        // X-Achsen-Beschriftung
        canvas.DrawText(DataSource.XAxisLabel, bounds.MidX, bounds.Bottom + 30, paint);

        // Y-Achsen-Beschriftung
        canvas.Save();
        canvas.RotateDegrees(-90);
        canvas.DrawText(DataSource.YAxisLabel, -bounds.MidY, bounds.Left - 40, paint);
        canvas.Restore();

        // Titel
        paint.TextSize = 16;
        canvas.DrawText(Title, bounds.MidX, bounds.Top - 10, paint);
    }

    protected override SKPoint ConvertDataToScreenPoint(IDataPoint dataPoint)
    {
        double xRange = DataSource.XMax.Value - DataSource.XMin.Value;
        double yRange = DataSource.YMax.Value - DataSource.YMin.Value;

        float x = (float)((dataPoint.X - DataSource.XMin.Value) / xRange * PlotBounds.Width + PlotBounds.Left);
        float y = (float)(PlotBounds.Bottom - (dataPoint.Y - DataSource.YMin.Value) / yRange * PlotBounds.Height);

        return new SKPoint(x, y);
    }
}
