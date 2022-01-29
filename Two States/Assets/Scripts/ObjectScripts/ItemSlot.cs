using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private UnityEvent onInsert;

    public void InsertItem(UseObject user)
    {
        UsableObject item = user.PickedObject.GetComponent<UsableObject>();
        user.DropObject();
        InsertItem(item);
    }
    public void InsertItem(UsableObject item)
    {
        item.transform.parent = point;
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
        onInsert.Invoke();
    }
}
