namespace SciPlot.Core;

public interface IDataSource
{
    IEnumerable<IDataSeries> Series { get; }
    string XAxisLabel { get; }
    string YAxisLabel { get; }
    double? XMin { get; }
    double? XMax { get; }
    double? YMin { get; }
    double? YMax { get; }
}
