using SciPlot.Core;
using SkiaSharp;

namespace SciPlot.Maui;

public abstract class MauiPlotBase : View, IPlot
{
    public static readonly BindableProperty DataSourceProperty = BindableProperty.Create(
        nameof(DataSource), typeof(object), typeof(MauiPlotBase), null);

    public object DataSource
    {
        get => GetValue(DataSourceProperty);
        set => SetValue(DataSourceProperty, value);
    }

    public abstract void Draw(SKCanvas canvas, SKRect bounds);
}
