using SciPlot.Core.Charts;
using SkiaSharp;

namespace SciPlot.Maui.Charts;

public class MauiLine : MauiPlotBase
{
    private readonly LineChart coreLineChart = new LineChart();

    public override void Draw(SKCanvas canvas, SKRect bounds)
    {
        coreLineChart.DataSource = DataSource;
        coreLineChart.Draw(canvas, bounds);
    }
}
