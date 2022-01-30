using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucket : MonoBehaviour
{
    [SerializeField] private string fireCode = "WATER";
    [SerializeField] private PickableObject pickable;
    [SerializeField] private C7_Player waterPlayer;

    public void PreAddWater()
    {
        waterPlayer.Play();
    }
    public void AddWater()
    {
        pickable.Code = fireCode;
    }

    public void PreRemoveWater()
    {
        if (waterPlayer.State == C7_Player.C7_Player_Play_State.notPlaying) { return; }
        waterPlayer.ForceContinue();
    }
    public void RemoveWater()
    {
        pickable.Code = "";
    }
}
