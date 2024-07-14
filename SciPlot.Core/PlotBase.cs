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

    public abstract void Draw(SKCanvas canvas, SKRect bounds);
}
