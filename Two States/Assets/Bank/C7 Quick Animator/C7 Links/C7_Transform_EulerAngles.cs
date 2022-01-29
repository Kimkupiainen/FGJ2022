using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C7_Transform_EulerAngles: C7_Var_Vector3
{
    public override Vector3 GetTargetValue()
    { return transform.localEulerAngles; }

    public override void UpdateTargetValue(Vector3 value)
    { transform.localEulerAngles = value; }
}
