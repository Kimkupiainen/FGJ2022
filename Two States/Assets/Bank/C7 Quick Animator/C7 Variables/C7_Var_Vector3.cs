using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public abstract class C7_Var_Vector3 : C7_Component
{
    [Tooltip("Recommended to keep values between -1 and 1. Use multiplier to scale to larger values.")]
    [SerializeField] private AnimationCurve morphXCurve = new AnimationCurve().Preset(0f);
    [Tooltip("Recommended to keep values between -1 and 1. Use multiplier to scale to larger values.")]
    [SerializeField] private AnimationCurve morphYCurve = new AnimationCurve().Preset(0f);
    [Tooltip("Recommended to keep values between -1 and 1. Use multiplier to scale to larger values.")]
    [SerializeField] private AnimationCurve morphZCurve = new AnimationCurve().Preset(0f);

    [Tooltip("Multiplies morpCurves value.")]
    [SerializeField] private Vector3 multiplier = Vector3.one;
    [Space(20)]
    [SerializeField] private Vector3 baseValue = Vector3.zero;

    public AnimationCurve MorphXCurve { get { return morphXCurve; } }
    public AnimationCurve MorphYCurve { get { return morphYCurve; } }
    public AnimationCurve MorphZCurve { get { return morphZCurve; } }
    public Vector3 Multiplier { get { return multiplier; } set { multiplier = value; } }
    public Vector3 BaseValue { get { return baseValue; } set { baseValue = value; } }

    private void OnValidate()
    {
        SetCurrentAsBase();
    }

    public override void UpdateState(float state)
    {
        UpdateTargetValue(
          BaseValue
           + new Vector3(
           MorphXCurve.Evaluate(state, Multiplier.x),
           MorphYCurve.Evaluate(state, Multiplier.y),
           MorphZCurve.Evaluate(state, Multiplier.z)
           ));
    }

    public abstract void UpdateTargetValue(Vector3 value);
    public abstract Vector3 GetTargetValue();

    public void SetCurrentAsBase() { BaseValue = GetTargetValue(); }
    public void SetEndValue(Vector3 endValue) { SetCurrentAsBase(); EndValue = endValue; }
    public Vector3 EndValue { get { return baseValue + multiplier; } set { multiplier = value - baseValue; } }
}
