using SciPlot.Core;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace SciPlot.Maui;

public class SciPlot : ContentView, ISciPlotController
{
    private SKCanvasView _canvasView;

    public SciPlot()
    {
        _canvasView = new SKCanvasView();
        _canvasView.PaintSurface += OnPaintSurface;
        Content = _canvasView;
    }

    public IList<IPlot> Plots { get; } = new List<IPlot>();

    public void InvalidateCanvas()
    {
        _canvasView.InvalidateSurface();
    }

    private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        var bounds = new SKRect(0, 0, e.Info.Width, e.Info.Height);

        canvas.Clear(SKColors.White);
        foreach (var plot in Plots)
        {
            plot.Draw(canvas, bounds);
        }
    }

    protected override void OnChildAdded(Element child)
    {
        base.OnChildAdded(child);
        if (child is IPlot plot)
        {
            Plots.Add(plot);
            InvalidateCanvas();
        }
    }

    protected override void OnChildRemoved(Element child, int oldLogicalIndex)
    {
        base.OnChildRemoved(child, oldLogicalIndex);
        if (child is IPlot plot)
        {
            Plots.Remove(plot);
            InvalidateCanvas();
        }
    }
}
