using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsVector3
{
    public static float GetLargestAxis(this Vector3 v)
    {
        if (v.x >= v.y && v.x >= v.z) { return v.x; }
        else if (v.y >= v.z) { return v.y; }
        else { return v.z; }
    }


    public static Vector3 SetAll(this Vector3 v, float value)
    { return v = new Vector3(value, value, value); }

    public static Vector3 SetX(this Vector3 v, float value)
    { return v = new Vector3(value, v.y, v.z); }

    public static Vector3 SetY(this Vector3 v, float value)
    { return v = new Vector3(v.x, value, v.z); }

    public static Vector3 SetZ(this Vector3 v, float value)
    { return v = new Vector3(v.x, v.y, value); }


    public static Vector3 Randomize(this Vector3 v, Vector2 range)
    { return new Vector3(Random.Range(range.x, range.y), Random.Range(range.x, range.y), Random.Range(range.x, range.y)); }

    public static Vector3 RandomizeZeroToRange(this Vector3 v, float range)
    { return new Vector3(Random.Range(0, range), Random.Range(0, range), Random.Range(0, range)); }

    public static Vector3 RandomizeNegativePositive(this Vector3 v, float range)
    { return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range)); }


    public static Vector3 Divide(this Vector3 v, Vector3 other)
    {
        if (other.x != 0) { v.x /= other.x; }
        else { v.x = 0; }
        if (other.y != 0) { v.y /= other.y; }
        else { v.y = 0; }
        if (other.z != 0) { v.z /= other.z; }
        else { v.z = 0; }

        return v;
    }

    public static Vector3 Multiply(this Vector3 v, Vector3 other)
    {
        v.x *= other.x;
        v.y *= other.y;
        v.z *= other.z;

        return v;
    }


    public static Vector3 Clamp01(this Vector3 v)
    {
        v.x = Mathf.Clamp01(v.x);
        v.y = Mathf.Clamp01(v.y);
        v.z = Mathf.Clamp01(v.z);
        return v;
    }

    public static Vector3 Clamp(this Vector3 v, float min, float max)
    {
        v.x = Mathf.Clamp(v.x, min, max);
        v.y = Mathf.Clamp(v.y, min, max);
        v.z = Mathf.Clamp(v.z, min, max);
        return v;
    }


    public static Vector3 NegativesToZero(this Vector3 v)
    {
        if (v.x < 0) { v.x = 0; }
        if (v.y < 0) { v.y = 0; }
        if (v.z < 0) { v.z = 0; }
        return v;
    }

    public static Vector3 Abs(this Vector3 v)
    {
        v.x = Mathf.Abs(v.x);
        v.y = Mathf.Abs(v.y);
        v.z = Mathf.Abs(v.z);
        return v;
    }


    public static Vector2 ToVector2(this Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }


    public static Vector3 DirectionTo(this Vector3 v, Vector3 target)
    {
        return new Vector3(target.x - v.x, target.y - v.y, target.z - v.z).normalized;
    }
    public static Vector3 DirectionTo(this Vector3 v, Transform target)
    { return v.DirectionTo(target.position); }
    public static Vector3 DirectionTo(this Vector3 v, GameObject target)
    { return v.DirectionTo(target.transform.position); }

    public static float DistanceTo(this Vector3 v, Vector3 target)
    {
        return Vector3.Distance(v, target);
    }
    public static float DistanceTo(this Vector3 v, Transform target)
    { return v.DistanceTo(target.position); }
    public static float DistanceTo(this Vector3 v, GameObject target)
    { return v.DistanceTo(target.transform.position); }
}
