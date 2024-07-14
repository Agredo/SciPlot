using SkiaSharp;

namespace SciPlot.Core;

public interface IPlot
{
    void Draw(SKCanvas canvas, SKRect bounds);
    object DataSource { get; set; }
}