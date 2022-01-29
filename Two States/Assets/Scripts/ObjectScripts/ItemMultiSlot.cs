using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemMultiSlot : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> slots = new List<ItemSlot>();
    [SerializeField] private UnityEvent OnComplete;

    public void ActivatedItem(ItemSlot slot)
    {
        slots.Remove(slot);
        if (slots.Count == 0)
        {
            OnComplete.Invoke();
        }
    }
}
