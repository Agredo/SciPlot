using SkiaSharp;

namespace SciPlot.Core;

public abstract class PlotBase : IPlot
{
    public string Title { get; set; } = string.Empty;
    public string XAxisTitle { get; set; } = string.Empty;
    public string YAxisTitle { get; set; } = string.Empty;
    public SKColor BackgroundColor { get; set; } = SKColors.White;
    public SKColor PlotAreaBackgroundColor { get; set; } = SKColors.LightGray;
    public SKColor GridLineColor { get; set; } = SKColors.Gray;
    public float GridLineThickness { get; set; } = 1f;
    public bool ShowLegend { get; set; } = true;
    public LegendPosition LegendPosition { get; set; } = LegendPosition.TopRight;
    public string FontFamily { get; set; } = string.Empty;
    public float FontSize { get; set; } = 12f;
    public double XAxisMin { get; set; } = double.NaN;
    public double XAxisMax { get; set; } = double.NaN;
    public double YAxisMin { get; set; } = double.NaN;
    public double YAxisMax { get; set; } = double.NaN;
    public bool AutoScaleX { get; set; } = true;
    public bool AutoScaleY { get; set; } = true;

    public IDataSource DataSource { get; set; } = default;

    protected SKRect PlotBounds { get; set; }

    public abstract void Draw(SKCanvas canvas, SKRect bounds);

    protected abstract SKPoint ConvertDataToScreenPoint(IDataPoint dataPoint);

    public virtual bool HitTest(SKPoint point, out IDataPoint hitPoint, out IDataSeries hitSeries)
    {
        hitPoint = null;
        hitSeries = null;

        if (DataSource == null) return false;

        const float hitTestTolerance = 10f; // 10 Pixel Toleranz

        foreach (var series in DataSource.Series)
        {
            foreach (var dataPoint in series.Points)
            {
                SKPoint screenPoint = ConvertDataToScreenPoint(dataPoint);

                if (CalculateDistance(point, screenPoint) <= hitTestTolerance)
                {
                    hitPoint = dataPoint;
                    hitSeries = series;
                    return true;
                }
            }
        }

        return false;
    }

    private float CalculateDistance(SKPoint p1, SKPoint p2)
    {
        return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}
