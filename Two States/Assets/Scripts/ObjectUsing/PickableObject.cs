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
    public List<UsableObjectType> UsableObjectTypes { get => usableObjectTypes; }

    [Tooltip("Use for key/lock combinations etc.")]
    [SerializeField] private string code = "";
    public string Code { get => code; }



    [Tooltip("Invoked if successfully used an object.")]
    [SerializeField] private UnityEvent onUse;
    public UnityEvent OnUse { get => onUse; }

    [Tooltip("Invoked if tried to use an object which cannot be used by this.")]
    [SerializeField] private UnityEvent onUnusable;
    public UnityEvent OnUnusable { get => onUnusable; }

    [Tooltip("Invoked if didn't hit anything or hit a blocking object.")]
    [SerializeField] private UnityEvent onNoHit;
    public UnityEvent OnNoHit { get => onNoHit; }



    [Space(40)]
    [Tooltip("Invoked if successfully used an object.")]
    [SerializeField] private UnityEventUseObject onPickup;
    public UnityEventUseObject OnPickup { get => onPickup; }

    [Tooltip("Invoked if successfully used an object.")]
    [SerializeField] private UnityEventUseObject onDrop;
    public UnityEventUseObject OnDrop { get => onDrop; }


    public void PickUp(UseObject User)
    {

    }
}

[System.Serializable]
public class UnityEventPickableObject : UnityEvent<PickableObject> { }

[System.Serializable]
public class UnityEventUsableObject : UnityEvent<UsableObject> { }

[System.Serializable]
public class UnityEventUseObject : UnityEvent<UseObject> { }