using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsColor
{
    public static string ColorToHex(Color32 color)
    { return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2"); }
    public static string ColorToHex(Color color)
    { return ColorToHex((Color32)color); }


    public static Color RGBDifference(this Color mainColor, Color comparison)
    {
        return new Color(comparison.r - mainColor.r, comparison.g - mainColor.g, comparison.b - mainColor.b, comparison.a - mainColor.a);
    }

    public static Color Dilute(this Color color)
    {
        Color result = color;

        float magnitude = 1.0000f;
        if (result.r > magnitude) { magnitude = result.r; }
        if (result.g > magnitude) { magnitude = result.g; }
        if (result.b > magnitude) { magnitude = result.b; }

        result = new Color(
            result.r / magnitude,
            result.g / magnitude,
            result.b / magnitude,
            result.a);

        return result;
    }

    /// <summary>
    /// Easier way to change just the alpha value of a color
    /// </summary>
    public static Color ChangeAlpha(this Color color, float amount)
    { return new Color(color.r, color.g, color.b, amount); }
    public static Color ChangeR(this Color color, float amount)
    { return new Color(amount, color.g, color.b, color.a); }
    public static Color ChangeG(this Color color, float amount)
    { return new Color(color.r, amount, color.b, color.a); }
    public static Color ChangeB(this Color color, float amount)
    { return new Color(color.r, color.g, amount, color.a); }
}