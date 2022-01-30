using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Kytkinboksi : MonoBehaviour
{
    [SerializeField] private List<Kytkin> kytkimet = new List<Kytkin>();
    [SerializeField] private UnityEvent onComplete;
    [SerializeField] private UnityEvent onDecomplete;
    public WaterSource WaterSource { get; set; }

    public bool IsCompleted { get; private set; } = false;
    public void TryComplete()
    {
        bool temp = IsCompleted;
        IsCompleted = TryCombination();
        if(IsCompleted != temp && IsCompleted)
        {  onComplete.Invoke();}
        else if(IsCompleted != temp && !IsCompleted)
        { onDecomplete.Invoke(); }

        WaterSource.TryComplete();
    }

    private bool TryCombination()
    {
        for (int i = 0; i < kytkimet.Count; i++)
        { if (!kytkimet[i].IsCorret()) { return false; } }
        return true;
    }
}

[System.Serializable]
public class Kytkin
{
    [SerializeField] private C7_Player player;
    [SerializeField] private bool requiredState;

    public bool IsCorret()
    {
        if (player.State == C7_Player.C7_Player_Play_State.paused && requiredState)
        { return true; }
        else if (player.State == C7_Player.C7_Player_Play_State.notPlaying && !requiredState)
        { return true; }
        return false;
    }
}