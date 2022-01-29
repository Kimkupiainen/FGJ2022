using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public abstract class C7_Var_Color : C7_Component
{
    [SerializeField] private Gradient morphGradient = new Gradient();
    [SerializeField] private C7_Var_Color_BlendMode BlendMode = C7_Var_Color_BlendMode.AlphaOverride;

    [Space(20)]
    [SerializeField] private Color baseValue = Color.black;

    public Gradient MorphGradient { get { return morphGradient; } set { morphGradient = value; } }

    [SerializeField] private bool UsePresetColorAsBaseValue = true;
    public Color BaseValue { get { return baseValue; } set { baseValue = value; } }


    public override void Awake()
    {
        if (UsePresetColorAsBaseValue) { BaseValue = GetTargetValue(); }
        base.Awake();
    }

    private Color tempColor;
    public override void UpdateState(float state)
    {

        switch (BlendMode)
        {
            case C7_Var_Color_BlendMode.Override:
                tempColor = MorphGradient.Evaluate(state);
                break;
            case C7_Var_Color_BlendMode.Additive:
                tempColor = BaseValue + MorphGradient.Evaluate(state);
                break;
            case C7_Var_Color_BlendMode.AlphaOverride:
                tempColor = MorphGradient.Evaluate(state);
                tempColor = (tempColor * tempColor.a) + (BaseValue * (1.00f - tempColor.a));
                tempColor.a = BaseValue.a;
                break;
        }

        UpdateTargetValue(tempColor);
    }

    public abstract void UpdateTargetValue(Color value);
    public abstract Color GetTargetValue();

    public enum C7_Var_Color_BlendMode
    {
        Override = 0,
        Additive = 1,
        AlphaOverride = 10,
    }
}
