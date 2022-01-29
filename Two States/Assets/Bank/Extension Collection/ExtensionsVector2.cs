using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsVector2
{
    public static float GetLargestAxis(this Vector2 v)
    {
        if (v.x >= v.y) { return v.x; }
        else { return v.y; }
    }


    public static Vector2 SetAll(this Vector2 v, float value)
    { return v = new Vector2(value, value); }

    public static Vector2 SetX(this Vector2 v, float value)
    { return v = new Vector2(value, v.y); }

    public static Vector2 SetY(this Vector2 v, float value)
    { return v = new Vector2(v.x, value); }


    public static Vector2 Randomize(this Vector2 v, Vector2 range)
    { return new Vector2(Random.Range(range.x, range.y), Random.Range(range.x, range.y)); }

    public static Vector2 RandomizeZeroToRange(this Vector2 v, float range)
    { return new Vector2(Random.Range(0, range), Random.Range(0, range)); }

    public static Vector2 RandomizeNegativePositive(this Vector2 v, float range)
    { return new Vector2(Random.Range(-range, range), Random.Range(-range, range)); }


    public static Vector2 Divide(this Vector2 v, Vector2 other)
    {
        if (other.x != 0) { v.x /= other.x; }
        else { v.x = 0; }
        if (other.y != 0) { v.y /= other.y; }
        else { v.y = 0; }

        return v;
    }

    public static Vector2 Multiply(this Vector2 v, Vector2 other)
    {
        v.x *= other.x;
        v.y *= other.y;
        return v;
    }


    public static Vector2 Clamp01(this Vector2 v)
    {
        v.x = Mathf.Clamp01(v.x);
        v.y = Mathf.Clamp01(v.y);
        return v;
    }

    public static Vector2 Clamp(this Vector2 v, float min, float max)
    {
        v.x = Mathf.Clamp(v.x, min, max);
        v.y = Mathf.Clamp(v.y, min, max);
        return v;
    }


    public static Vector2 NegativesToZero(this Vector2 v)
    {
        if (v.x < 0) { v.x = 0; }
        if (v.y < 0) { v.y = 0; }
        return v;
    }

    public static Vector2 Abs(this Vector2 v)
    {
        v.x = Mathf.Abs(v.x);
        v.y = Mathf.Abs(v.y);
        return v;
    }


    public static Vector3 ToVector3Topdown(this Vector2 v, float Y = 0)
    {
        return new Vector3(v.x, Y, v.y);
    }
    public static Vector3 ToVector3(this Vector2 v, float Z = 0)
    {
        return new Vector3(v.x, v.y, Z);
    }


    public static Vector2 DirectionTo(this Vector2 v, Vector2 target)
    {
        return new Vector2(target.x - v.x, target.y - v.y).normalized;
    }
    public static Vector2 DirectionTo(this Vector2 v, Transform target)
    { return v.DirectionTo(target.position); }
    public static Vector2 DirectionTo(this Vector2 v, GameObject target)
    { return v.DirectionTo(target.transform.position); }

    public static float DistanceTo(this Vector2 v, Vector2 target)
    {
        return Vector2.Distance(v, target);
    }
    public static float DistanceTo(this Vector2 v, Transform target)
    { return v.DistanceTo(target.position); }
    public static float DistanceTo(this Vector2 v, GameObject target)
    { return v.DistanceTo(target.transform.position); }


    public static float ToAngle360(this Vector2 v, Vector2 direction)
    {
        float angle = Vector2.Angle(direction, v);
        if (v.x > 0) { angle = 360 - angle; }
        return angle;
    }
    public static float ToAngle360Right(this Vector2 v)
    {
        return v.ToAngle360(Vector2.right);
    }
    public static float ToAngle360Down(this Vector2 v)
    {
        return v.ToAngle360(Vector2.down);
    }

    public static float ToAngle180(this Vector2 v, Vector2 direction)
    {
        float angle = Vector2.Angle(direction, v);
        if (v.x > 0) { angle *= -1; }
        return angle;
    }
    public static float ToAngle180Right(this Vector2 v)
    {
        return v.ToAngle180(Vector2.right);
    }
    public static float ToAngle180Down(this Vector2 v)
    {
        return v.ToAngle180(Vector2.down);
    }
}