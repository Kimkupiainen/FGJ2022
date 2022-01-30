using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : MonoBehaviour
{
    [SerializeField] private C7_Player player;
    public void FillBucket(UseObject user)
    {
        WaterBucket wb = user.PickedObject.GetComponent<WaterBucket>();
        if (wb != null) { wb.PreAddWater(); }
    }

    public void Waterstate(bool isOn)
    {
        if (isOn) { player.Play(); }
        else { player.ForceContinue(); }
    }
}
