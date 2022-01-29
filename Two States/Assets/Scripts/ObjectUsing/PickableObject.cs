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



    [SerializeField] private OnEvent<UseObject> onEvents;
    public OnEvent<UseObject> OnEvents { get => onEvents; }


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