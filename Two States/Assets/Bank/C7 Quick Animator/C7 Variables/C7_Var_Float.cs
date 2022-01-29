using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public abstract class C7_Var_Float : C7_Component
{
    [Tooltip("Recommended to keep values between -1 and 1. Use multiplier to scale to larger values.")]
    [SerializeField] private AnimationCurve morphCurve = new AnimationCurve().Preset(0f);

    [Tooltip("Multiplies morpCurves value.")]
    [SerializeField] private float multiplier = 1.0f;
    [Space(20)]
    [SerializeField] private float baseValue = 0.0f;

    public AnimationCurve MorphCurve { get { return morphCurve; } }
    public float Multiplier { get { return multiplier; } set { multiplier = value; } }
    public float BaseValue { get { return baseValue; } set { baseValue = value; } }


    public override void UpdateState(float state)
    {
        UpdateTargetValue(
            BaseValue
            + MorphCurve.Evaluate(state, Multiplier));
    }

    public abstract void UpdateTargetValue(float value);
    public abstract float GetTargetValue();
}