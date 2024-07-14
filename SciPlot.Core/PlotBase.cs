using SkiaSharp;

namespace SciPlot.Core;

public abstract class PlotBase : IPlot
{
    public object DataSource { get; set; }
    public abstract void Draw(SKCanvas canvas, SKRect bounds);
}
