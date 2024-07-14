using LineChartCore = SciPlot.Core.Charts.LineChart;
using SkiaSharp;
using SciPlot.Core;

namespace SciPlot.Maui.Charts;

public class MauiLine : MauiPlotBase
{
    private readonly LineChartCore coreLineChart = new LineChartCore();

    public MauiLine(PlotBase corePlot) : base(corePlot)
    {
    }

    public override void Draw(SKCanvas canvas, SKRect bounds)
    {
        coreLineChart.DataSource = DataSource;
        coreLineChart.Draw(canvas, bounds);
    }
}
