namespace SciPlot.Core.EventArguments;

public class DataPointClickedEventArgs : EventArgs
{
    public IPlot Plot { get; }
    public IDataSeries Series { get; }
    public IDataPoint DataPoint { get; }

    public DataPointClickedEventArgs(IPlot plot, IDataSeries series, IDataPoint dataPoint)
    {
        Plot = plot;
        Series = series;
        DataPoint = dataPoint;
    }
}