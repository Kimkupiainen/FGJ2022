using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C7_Light_intensity : C7_Var_Float
{
    [SerializeField] private Light lightSource;
    private void OnValidate()
    {
        this.ValidateComponent(ref lightSource);
    }
    public override float GetTargetValue()
    {
        return lightSource.intensity;
    }

    public override void UpdateTargetValue(float value)
    {
        lightSource.intensity = value;
    }
}
