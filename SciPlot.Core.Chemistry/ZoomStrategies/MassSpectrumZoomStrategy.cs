using SciPlot.Core.ZoomStratagies;
using SkiaSharp;

namespace SciPlot.Core.Charts.Chemistry.ZoomStrategies;

public class MassSpectrumZoomStrategy : IZoomStrategy
{
    public void ApplyZoom(IPlot plot, SKPoint zoomCenter, float zoomFactor)
    {
        var dataSource = plot.DataSource;
        var plotBounds = plot.PlotBounds;

        // Calculate the relative X position of the zoom center
        double relativeX = (zoomCenter.X - plotBounds.Left) / plotBounds.Width;

        // Calculate the new X range
        double currentXRange = dataSource.XMax.Value - dataSource.XMin.Value;
        double newXRange = currentXRange / zoomFactor;
        double newXMin = dataSource.XMin.Value + (currentXRange - newXRange) * relativeX;
        double newXMax = newXMin + newXRange;

        // Update the X range
        dataSource.XMin = newXMin;
        dataSource.XMax = newXMax;

        // Calculate the relative Y position of the zoom center
        dataSource.YMin = 0;
        dataSource.YMax = dataSource.Series.SelectMany(s => s.Points).Max(p => p.Y);
    }
}
