using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Colorx
{
    /// <summary>
    /// Outputs random color hue within wanted saturation
    /// </summary>
    public static Color RandomColor(Vector2 capValues)
    { return RandomColor(capValues, 1); }

    public static Color RandomColor(Vector2 capValues, float alpha)
    {
        List<float> rgbValues = new List<float>();
        rgbValues.Add(capValues.x);
        rgbValues.Add(capValues.y);
        rgbValues.Add(Random.Range(capValues.x, capValues.y));

        Color newColor = new Color();
        int i = Random.Range(0, 3);
        newColor.r = rgbValues[i];
        rgbValues.RemoveAt(i);

        i = Random.Range(0, 2);
        newColor.g = rgbValues[i];
        rgbValues.RemoveAt(i);

        newColor.b = rgbValues[0];
        newColor.a = 1;
        return newColor;
    }
}
