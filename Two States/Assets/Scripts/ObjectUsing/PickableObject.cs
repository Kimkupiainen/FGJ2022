using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UsableObject))]
public class PickableObject : MonoBehaviour
{
    private void OnValidate()
    {
        if (UsableObjectTypes.Count == 0) { UsableObjectTypes.Add(UsableObjectType.pickable); }


#if UNITY_EDITOR
        UsableObject linkedUsableObjectComponent = GetComponent<UsableObject>();
        linkedUsableObjectComponent.OnUse.OnValidateOnlyAddEvent<UseObject>(PickUp);
#endif
    }

    [Tooltip("Object types which can be used if this object is picked up. Including pickable allows swapping objects without extra dropping.")]
    [SerializeField] private List<UsableObjectType> usableObjectTypes = new List<UsableObjectType>();
    public List<UsableObjectType> UsableObjectTypes { get => usableObjectTypes; set => usableObjectTypes = value; }

    [Tooltip("Use for key/lock combinations etc.")]
    [SerializeField] private string code = "";
    public string Code { get => code; set => code = value; }



    [SerializeField] private OnEvent<UseObject> onEvents;
    public OnEvent<UseObject> OnEvents { get => onEvents; }


    [SerializeField] private Collider col;
    [SerializeField] private Rigidbody rb;
    public void PickUp(UseObject user)
    {
        if (col != null) { col.enabled = false; }
        if (rb != null) { rb.isKinematic = true; }
        transform.parent = user.Hand.transform;
        transform.position = user.Hand.transform.position;
        transform.localEulerAngles = Vector3.zero;
        user.PickObject(this);
        OnEvents.Invoke(OnEventType.OnPickup, user);
    }

    public void Drop(UseObject user)
    {
        if (col != null) { col.enabled = true; }
        if (rb != null) { rb.isKinematic = false; }
        transform.parent = null;
        OnEvents.Invoke(OnEventType.OnDrop, user);
    }
}

[System.Serializable]
public class UnityEventPickableObject : UnityEvent<PickableObject> { }

[System.Serializable]
public class UnityEventUsableObject : UnityEvent<UsableObject> { }

[System.Serializable]
public class UnityEventUseObject : UnityEvent<UseObject> { }