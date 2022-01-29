using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C7_MeshRend_Color : C7_Var_Color
{
    [SerializeField] private MeshRenderer rend;
    public MeshRenderer Rend => rend;

    private void OnValidate()
    {
        this.ValidateComponent(ref rend);
    }
    private void Start()
    {
        rend.material = Instantiate<Material>(rend.material);
    }
    public override Color GetTargetValue()
    {
        return rend.material.GetColor("_Color");
    }

    public override void UpdateTargetValue(Color value)
    {
        rend.material.SetColor("_Color", value);
    }
}
