using SkiaSharp;

namespace SciPlot.Core;

public interface IDataSeries
{
    string Name { get; }
    IEnumerable<IDataPoint> Points { get; }
    SKColor Color { get; }
}
