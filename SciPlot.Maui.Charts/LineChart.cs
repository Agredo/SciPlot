using SkiaSharp;
using LineChartCore = SciPlot.Core.Charts.LineChart;

namespace SciPlot.Maui.Charts;

public class MauiLine : MauiPlotBase
{
    private readonly LineChartCore coreLineChart = new LineChartCore();

    public override void Draw(SKCanvas canvas, SKRect bounds)
    {
        coreLineChart.DataSource = DataSource;
        coreLineChart.Draw(canvas, bounds);
    }
}
