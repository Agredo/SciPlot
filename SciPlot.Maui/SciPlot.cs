using SciPlot.Core;
using SciPlot.Core.EventArguments;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace SciPlot.Maui;

public class SciPlot : ContentView, ISciPlotController
{
    private SKCanvasView canvasView;

    public event EventHandler<PlotClickedEventArgs>? PlotClicked;
    public event EventHandler<DataPointClickedEventArgs>? DataPointClicked;

    public SciPlot()
    {
        canvasView = new SKCanvasView();
        canvasView.PaintSurface += OnPaintSurface;

        canvasView.EnableTouchEvents = true;
        canvasView.Touch += OnTouch;

        Content = canvasView;
    }

    private void OnTouch(object? sender, SKTouchEventArgs e)
    {
        if (e.ActionType == SKTouchAction.Released)
        {
            var touchPoint = new SKPoint(e.Location.X, e.Location.Y);

            foreach (var plot in Plots)
            {
                if (plot.HitTest(touchPoint, out var hitPoint, out var hitSeries))
                {
                    DataPointClicked?.Invoke(this, new DataPointClickedEventArgs(plot, hitSeries, hitPoint));
                    return;
                }
            }

            // No data point was hit, so we raise the PlotClicked event
            PlotClicked?.Invoke(this, new PlotClickedEventArgs(touchPoint));
        }
    }

    public IList<IPlot> Plots { get; } = new List<IPlot>();

    public void InvalidateCanvas()
    {
        canvasView.InvalidateSurface();
    }

    private void OnPaintSurface(object? sender, SKPaintSurfaceEventArgs e)
    {
        Console.WriteLine("OnPaintSurface wird aufgerufen");
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
