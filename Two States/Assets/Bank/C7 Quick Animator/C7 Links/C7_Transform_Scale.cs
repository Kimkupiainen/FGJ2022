using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C7_Transform_Scale : C7_Var_Vector3
{
    public override Vector3 GetTargetValue()
    { return transform.localScale; }

    public override void UpdateTargetValue(Vector3 value)
    { transform.localScale = value; }
}
