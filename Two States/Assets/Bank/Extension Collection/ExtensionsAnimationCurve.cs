using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsAnimationCurve
{
    public static AnimationCurve Preset(this AnimationCurve ac, float value)
    {
        ac.preWrapMode = WrapMode.ClampForever;
        ac.postWrapMode = WrapMode.ClampForever;
        ac.AddKey(0, value);
        ac.AddKey(1, value);
        return ac;
    }

    public static float Evaluate(this AnimationCurve ac, float time, float magnitude)
    { return ac.Evaluate(time) * magnitude; }

    public static float EvaluateDividive(this AnimationCurve curve, float time, float magnitude)
    {
        float result = curve.Evaluate(time);
        result *= magnitude;
        if (result > 0)
        {
            result++;
        }
        else if (result < 0 && magnitude != 0)
        {
            result--;
            result = 1 / -result;
        }
        else
        {
            result = 1;
        }
        return result;
    }

    public static void Smooth(this AnimationCurve ac)
    {
        Keyframe[] keyframes = ac.keys;

        for (int i = 0; i < keyframes.Length; i++)
        {
            keyframes[i].inTangent = 0f;
            keyframes[i].outTangent = 0f;
            keyframes[i].inWeight = 0.33333f;
            keyframes[i].outWeight = 0.33333f;
        }

        ac.keys = keyframes;
        ac.preWrapMode = WrapMode.ClampForever;
        ac.postWrapMode = WrapMode.ClampForever;
    }
    public static void CustomSmooth(this AnimationCurve ac, List<Vector4> values)
    {
        Keyframe[] keyframes = ac.keys;

        for (int i = 0; i < keyframes.Length; i++)
        {
            keyframes[i].inTangent = values[i].x;
            keyframes[i].outTangent = values[i].y;
            keyframes[i].inWeight = values[i].z;
            keyframes[i].outWeight = values[i].x;
        }

        ac.keys = keyframes;
        ac.preWrapMode = WrapMode.ClampForever;
        ac.postWrapMode = WrapMode.ClampForever;
    }

    public static string PrintCurvePoints(this AnimationCurve ac, int id)
    {
        Keyframe[] keyframes = ac.keys;

        return "in T: " + (keyframes[id].inTangent * 100f) + " W: " + (keyframes[id].inWeight * 100f) +
            " - out T: " + (keyframes[id].outTangent * 100f) + " W: " + (keyframes[id].outWeight * 100f);
    }
}