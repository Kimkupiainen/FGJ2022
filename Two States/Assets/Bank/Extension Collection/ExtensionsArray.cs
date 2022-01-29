using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsArray
{
    /// <summary>
    /// Sets value only if the array is long enough
    /// </summary>
    public static void SafeSet<T>(this T[] array, int id, ref T var)
    {
        if (array.Length <= id) { return; }
        var = array[id];
    }
}