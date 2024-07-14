namespace SciPlot.Core;

public interface ISciPlotController
{
    IList<IPlot> Plots { get; }
    void InvalidateCanvas();
}
