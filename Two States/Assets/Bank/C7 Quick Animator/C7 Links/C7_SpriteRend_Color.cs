using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C7_SpriteRend_Color : C7_Var_Color
{
    [SerializeField] private SpriteRenderer rend;
    private void OnValidate()
    { this.ValidateComponent(ref rend); }

    public override Color GetTargetValue()
    { return rend.color; }

    public override void UpdateTargetValue(Color value)
    { rend.color = value; }
}
