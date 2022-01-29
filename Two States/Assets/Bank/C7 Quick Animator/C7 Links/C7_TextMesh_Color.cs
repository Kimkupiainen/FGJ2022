using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C7_TextMesh_Color : C7_Var_Color
{
    [SerializeField] private TextMesh textMesh;
    private void OnValidate()
    {
        this.ValidateComponent(ref textMesh);
    }
    public override Color GetTargetValue()
    {
        return textMesh.color;
    }

    public override void UpdateTargetValue(Color value)
    {
        textMesh.color = value;
    }
}
