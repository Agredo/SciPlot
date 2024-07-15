using SkiaSharp;

namespace SciPlot.Core.EventArguments;

public class PlotClickedEventArgs : EventArgs
{
    public SKPoint ClickLocation { get; }

    public PlotClickedEventArgs(SKPoint clickLocation)
    {
        ClickLocation = clickLocation;
    }
}