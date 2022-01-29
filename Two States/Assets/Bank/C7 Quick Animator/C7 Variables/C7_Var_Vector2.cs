using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public abstract class C7_Var_Vector2 : C7_Component
{
    [Tooltip("Recommended to keep values between -1 and 1. Use multiplier to scale to larger values.")]
    [SerializeField] private AnimationCurve morphXCurve = new AnimationCurve().Preset(0f);
    [Tooltip("Recommended to keep values between -1 and 1. Use multiplier to scale to larger values.")]
    [SerializeField] private AnimationCurve morphYCurve = new AnimationCurve().Preset(0f);

    [Tooltip("Multiplies morpCurves value.")]
    [SerializeField] private float multiplier = 1.0f;
    [Space(20)]
    [SerializeField] private Vector2 baseValue = Vector2.zero;

    public AnimationCurve MorphXCurve { get { return morphXCurve; } }
    public AnimationCurve MorphYCurve { get { return morphYCurve; } }
    public float Multiplier { get { return multiplier; } set { multiplier = value; } }
    public Vector2 BaseValue { get { return baseValue; } set { baseValue = value; } }


    public override void UpdateState(float state)
    {
        UpdateTargetValue(
          BaseValue
          + new Vector2(
          MorphXCurve.Evaluate(state, Multiplier),
          MorphYCurve.Evaluate(state, Multiplier)
          ));
    }

    public abstract void UpdateTargetValue(Vector2 value);
    public abstract Vector2 GetTargetValue();
}
