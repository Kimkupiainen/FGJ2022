using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C7_Transform_Position : C7_Var_Vector3
{
    [SerializeField] private C7_Enums.Region region = C7_Enums.Region.local;
    public override Vector3 GetTargetValue()
    {
        switch (region)
        {
            case C7_Enums.Region.local:
                return transform.localPosition;
            case C7_Enums.Region.global:
                return transform.position;
            default:
                return Vector3.zero;
        }
    }

    public override void UpdateTargetValue(Vector3 value)
    {
        switch (region)
        {
            case C7_Enums.Region.local:
                transform.localPosition = value;
                break;
            case C7_Enums.Region.global:
                transform.position = value;
                break;
            default:
                break;
        }
    }
}