using SkiaSharp;

namespace SciPlot.Core;

public interface IPlot
{

    string Title { get; set; }
    string XAxisTitle { get; set; }
    string YAxisTitle { get; set; }
    SKColor BackgroundColor { get; set; }
    SKColor PlotAreaBackgroundColor { get; set; }
    SKColor GridLineColor { get; set; }
    float GridLineThickness { get; set; }
    bool ShowLegend { get; set; }
    LegendPosition LegendPosition { get; set; }
    string FontFamily { get; set; }
    float FontSize { get; set; }
    double XAxisMin { get; set; }
    double XAxisMax { get; set; }
    double YAxisMin { get; set; }
    double YAxisMax { get; set; }
    bool AutoScaleX { get; set; }
    bool AutoScaleY { get; set; }

    IDataSource DataSource { get; set; }

    void Draw(SKCanvas canvas, SKRect bounds);
    public abstract bool HitTest(SKPoint point, out IDataPoint hitPoint, out IDataSeries hitSeries);
}