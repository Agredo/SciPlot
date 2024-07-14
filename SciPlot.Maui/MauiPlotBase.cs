using SciPlot.Core;
using SkiaSharp;

namespace SciPlot.Maui;

public abstract class MauiPlotBase : View, IPlot
{
    protected readonly PlotBase CorePlot;

    public MauiPlotBase(PlotBase corePlot)
    {
        CorePlot = corePlot;
    }

    //Bindable Properties
    public static readonly BindableProperty DataSourceProperty = BindableProperty.Create(
        nameof(DataSource), typeof(IDataSource), typeof(MauiPlotBase), null, propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.DataSource = (IDataSource)newValue);

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(MauiPlotBase), string.Empty,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.Title = (string)newValue);

    public static readonly BindableProperty XAxisTitleProperty =
        BindableProperty.Create(nameof(XAxisTitle), typeof(string), typeof(MauiPlotBase), string.Empty,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.XAxisTitle = (string)newValue);

    public static readonly BindableProperty YAxisTitleProperty =
        BindableProperty.Create(nameof(YAxisTitle), typeof(string), typeof(MauiPlotBase), string.Empty,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.YAxisTitle = (string)newValue);

    public static readonly BindableProperty PlotAreaBackgroundColorProperty =
        BindableProperty.Create(nameof(PlotAreaBackgroundColor), typeof(SKColor), typeof(MauiPlotBase), SKColors.Transparent,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.PlotAreaBackgroundColor = (SKColor)newValue);

    public static readonly BindableProperty GridLineColorProperty =
        BindableProperty.Create(nameof(GridLineColor), typeof(SKColor), typeof(MauiPlotBase), SKColors.LightGray,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.GridLineColor = (SKColor)newValue);

    public static readonly BindableProperty GridLineThicknessProperty =
        BindableProperty.Create(nameof(GridLineThickness), typeof(float), typeof(MauiPlotBase), 1f,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.GridLineThickness = (float)newValue);

    public static readonly BindableProperty ShowLegendProperty =
        BindableProperty.Create(nameof(ShowLegend), typeof(bool), typeof(MauiPlotBase), true,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.ShowLegend = (bool)newValue);

    public static readonly BindableProperty LegendPositionProperty =
        BindableProperty.Create(nameof(LegendPosition), typeof(LegendPosition), typeof(MauiPlotBase), LegendPosition.TopRight,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.LegendPosition = (LegendPosition)newValue);

    public static readonly BindableProperty FontFamilyProperty =
        BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MauiPlotBase), string.Empty,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.FontFamily = (string)newValue);

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(float), typeof(MauiPlotBase), 12f,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.FontSize = (float)newValue);

    public static readonly BindableProperty XAxisMinProperty =
        BindableProperty.Create(nameof(XAxisMin), typeof(double), typeof(MauiPlotBase), double.NaN,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.XAxisMin = (double)newValue);

    public static readonly BindableProperty XAxisMaxProperty =
        BindableProperty.Create(nameof(XAxisMax), typeof(double), typeof(MauiPlotBase), double.NaN,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.XAxisMax = (double)newValue);

    public static readonly BindableProperty YAxisMinProperty =
        BindableProperty.Create(nameof(YAxisMin), typeof(double), typeof(MauiPlotBase), double.NaN,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.YAxisMin = (double)newValue);

    public static readonly BindableProperty YAxisMaxProperty =
        BindableProperty.Create(nameof(YAxisMax), typeof(double), typeof(MauiPlotBase), double.NaN,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.YAxisMax = (double)newValue);

    public static readonly BindableProperty AutoScaleXProperty =
        BindableProperty.Create(nameof(AutoScaleX), typeof(bool), typeof(MauiPlotBase), true,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.AutoScaleX = (bool)newValue);

    public static readonly BindableProperty AutoScaleYProperty =
        BindableProperty.Create(nameof(AutoScaleY), typeof(bool), typeof(MauiPlotBase), true,
            propertyChanged: (bindable, oldValue, newValue) =>
                ((MauiPlotBase)bindable).CorePlot.AutoScaleY = (bool)newValue);

    SKColor IPlot.BackgroundColor
    {
        get => CorePlot.BackgroundColor;
        set => CorePlot.BackgroundColor = value;
    }

    public IDataSource DataSource
    {
        get => (IDataSource)GetValue(DataSourceProperty);
        set => SetValue(DataSourceProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string XAxisTitle
    {
        get => (string)GetValue(XAxisTitleProperty);
        set => SetValue(XAxisTitleProperty, value);
    }

    public string YAxisTitle
    {
        get => (string)GetValue(YAxisTitleProperty);
        set => SetValue(YAxisTitleProperty, value);
    }

    public SKColor PlotAreaBackgroundColor
    {
        get => (SKColor)GetValue(PlotAreaBackgroundColorProperty);
        set => SetValue(PlotAreaBackgroundColorProperty, value);
    }

    public SKColor GridLineColor
    {
        get => (SKColor)GetValue(GridLineColorProperty);
        set => SetValue(GridLineColorProperty, value);
    }

    public float GridLineThickness
    {
        get => (float)GetValue(GridLineThicknessProperty);
        set => SetValue(GridLineThicknessProperty, value);
    }

    public bool ShowLegend
    {
        get => (bool)GetValue(ShowLegendProperty);
        set => SetValue(ShowLegendProperty, value);
    }

    public LegendPosition LegendPosition
    {
        get => (LegendPosition)GetValue(LegendPositionProperty);
        set => SetValue(LegendPositionProperty, value);
    }

    public string FontFamily
    {
        get => (string)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    public float FontSize
    {
        get => (float)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public double XAxisMin
    {
        get => (double)GetValue(XAxisMinProperty);
        set => SetValue(XAxisMinProperty, value);
    }

    public double XAxisMax
    {
        get => (double)GetValue(XAxisMaxProperty);
        set => SetValue(XAxisMaxProperty, value);
    }

    public double YAxisMin
    {
        get => (double)GetValue(YAxisMinProperty);
        set => SetValue(YAxisMinProperty, value);
    }

    public double YAxisMax
    {
        get => (double)GetValue(YAxisMaxProperty);
        set => SetValue(YAxisMaxProperty, value);
    }

    public bool AutoScaleX
    {
        get => (bool)GetValue(AutoScaleXProperty);
        set => SetValue(AutoScaleXProperty, value);
    }

    public bool AutoScaleY
    {
        get => (bool)GetValue(AutoScaleYProperty);
        set => SetValue(AutoScaleYProperty, value);
    }



    public abstract void Draw(SKCanvas canvas, SKRect bounds);
}
