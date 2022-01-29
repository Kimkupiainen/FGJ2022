using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsTransform
{
    /// <summary>
    /// Reset transform values to default
    /// </summary>
    public static void Reset(this Transform t)
    {
        t.localPosition = Vector3.zero;
        t.rotation = Quaternion.identity;
        t.localScale = Vector3.one;
    }

    /// <summary>
    /// Returns lossyScale ignoring rotations
    /// </summary>
    public static Vector3 TotalScale(this Transform t)
    {
        Transform b = t;
        Vector3 result = Vector3.one;
        while (b != null)
        {
            result = result.Multiply(b.localScale);
            if (b.parent != null)
            { b = b.parent; }
            else
            { b = null; break; }
        }
        return result;
    }

    public static Vector3 DirectionTo(this Transform t, Vector3 target)
    { return t.position.DirectionTo(target); }
    public static Vector3 DirectionTo(this Transform t, Transform target)
    { return t.position.DirectionTo(target.position); }
    public static Vector3 DirectionTo(this Transform t, GameObject target)
    { return t.position.DirectionTo(target.transform.position); }

    public static float DistanceTo(this Transform t, Vector3 target)
    { return t.position.DistanceTo(target); }
    public static float DistanceTo(this Transform t, Transform target)
    { return t.position.DistanceTo(target.position); }
    public static float DistanceTo(this Transform t, GameObject target)
    { return t.position.DistanceTo(target.transform.position); }
}
