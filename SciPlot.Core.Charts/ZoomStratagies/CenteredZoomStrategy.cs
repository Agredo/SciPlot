using SciPlot.Core.ZoomStratagies;
using SkiaSharp;

namespace SciPlot.Core.Charts.ZoomStratagies;

public class CenteredZoomStrategy : IZoomStrategy
{
    public void ApplyZoom(IPlot plot, SKPoint zoomCenter, float zoomFactor)
    {
        IDataSource? dataSource = plot.DataSource;
        SKRect plotBounds = plot.PlotBounds;

        // Calculate the relative position of the zoom center
        double relativeX = (zoomCenter.X - plotBounds.Left) / plotBounds.Width;
        double relativeY = (plotBounds.Bottom - zoomCenter.Y) / plotBounds.Height;

        // Calculate the new data range
        double currentXRange = dataSource.XMax.Value - dataSource.XMin.Value;
        double currentYRange = dataSource.YMax.Value - dataSource.YMin.Value;
        double newXRange = currentXRange / zoomFactor;
        double newYRange = currentYRange / zoomFactor;

        double newXMin = dataSource.XMin.Value + (currentXRange - newXRange) * relativeX;
        double newXMax = newXMin + newXRange;
        double newYMin = dataSource.YMin.Value + (currentYRange - newYRange) * relativeY;
        double newYMax = newYMin + newYRange;

        dataSource.XMin = newXMin;
        dataSource.XMax = newXMax;
        dataSource.YMin = newYMin;
        dataSource.YMax = newYMax;
    }
}