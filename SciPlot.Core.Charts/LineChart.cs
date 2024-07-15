using SkiaSharp;

namespace SciPlot.Core.Charts;

public class LineChart : PlotBase
{
    public override void Draw(SKCanvas canvas, SKRect bounds)
    {
    }

    protected override SKPoint ConvertDataToScreenPoint(IDataPoint dataPoint)
    {
        // Implementation of the conversion from data to screen coordinates
        // This method is specific to the LineChart and takes axis scaling into account

        double xRange = DataSource.XMax!.Value - DataSource.XMin!.Value;
        double yRange = DataSource.YMax!.Value - DataSource.YMin!.Value;

        float x = (float)((dataPoint.X - DataSource.XMin.Value) / xRange * PlotBounds.Width + PlotBounds.Left);
        float y = (float)(PlotBounds.Bottom - (dataPoint.Y - DataSource.YMin.Value) / yRange * PlotBounds.Height);

        return new SKPoint(x, y);
    }
}
