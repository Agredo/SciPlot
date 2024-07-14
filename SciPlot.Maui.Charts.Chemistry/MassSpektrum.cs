
using SciPlot.Core;
using SkiaSharp;
using MassSpektrumCore = SciPlot.Core.Chemistry.MassSpektrum;

namespace SciPlot.Maui.Charts.Chemistry;

// All the code in this file is included in all platforms.
public class MassSpektrum : MauiPlotBase
{
    private readonly MassSpektrumCore coreMassSpektrum = new MassSpektrumCore();

    public MassSpektrum(PlotBase corePlot) : base(corePlot)
    {
    }

    public override void Draw(SKCanvas canvas, SKRect bounds)
    {
        coreMassSpektrum.DataSource = DataSource;
        coreMassSpektrum.Draw(canvas, bounds);
    }
}
