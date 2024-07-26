using SkiaSharp;

namespace SciPlot.Core.ZoomStratagies;
public interface IZoomStrategy
{
    void ApplyZoom(IPlot plot, SKPoint zoomCenter, float zoomFactor);
}
