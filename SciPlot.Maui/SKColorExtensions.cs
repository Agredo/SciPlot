using SkiaSharp;

namespace SciPlot.Maui;

public static class SKColorExtensions
{
    public static SKColor ToSkColor(this Color target, float alpha = 1)
    {
        var r = (byte)(target.Red * 255f);
        var g = (byte)(target.Green * 255f);
        var b = (byte)(target.Blue * 255f);
        var a = (byte)(target.Alpha * 255f * alpha);

        return new SKColor(r, g, b, a);
    }

    public static Color ToMauiColor(this SKColor target)
    {
        return new Color(target.Red / 255, target.Green / 255, target.Green / 255, target.Alpha / 255);
    }
}
