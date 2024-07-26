namespace SciPlot.Core;

public interface IDataSource
{
    IEnumerable<IDataSeries> Series { get; }
    string XAxisLabel { get; }
    string YAxisLabel { get; }
    double? XMin { get; set; }
    double? XMax { get; set; }
    double? YMin { get; set; }
    double? YMax { get; set; }
}
