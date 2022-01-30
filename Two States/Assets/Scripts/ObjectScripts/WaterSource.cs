using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : MonoBehaviour
{
    [SerializeField] private List<Kytkinboksi> kytkimet = new List<Kytkinboksi>();
    [SerializeField] private C7_Player player;

    private void Start()
    {
        for (int i = 0; i < kytkimet.Count; i++)
        { kytkimet[i].WaterSource = this; }
    }

    public void TryComplete()
    {
        for (int i = 0; i < kytkimet.Count; i++)
        {
            if (!kytkimet[i].IsCompleted)
            {
                if (state) { Waterstate(false); }
                return;
            }
        }

        Waterstate(true);
    }

    public void FillBucket(UseObject user)
    {
        WaterBucket wb = user.PickedObject.GetComponent<WaterBucket>();
        if (wb != null) { wb.PreAddWater(); }
    }

    private bool state = false;
    public void Waterstate(bool isOn)
    {
        state = isOn;
        if (isOn) { player.Play(); }
        else { player.ForceContinue(); }
    }
}
