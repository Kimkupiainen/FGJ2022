using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsableObject : MonoBehaviour
{
    [SerializeField] private UsableObjectType objectType = UsableObjectType.unusable;
    public UsableObjectType ObjectType { get => objectType; }

    [Tooltip("Requires an object with a matching code to be used. Otherwise leave empty.")]
    [SerializeField] private string code = "";
    public string Code { get => code; }

    [Tooltip("Invoked if someone successfully used this object.")]
    [SerializeField] private UnityEventUseObject onUse;
    public UnityEventUseObject OnUse { get => onUse; }

    private void OnValidate()
    {
        if (gameObject.layer != 15) { gameObject.layer = 15; }//15 should be "UsableObject"
    }

    /// <returns>True if successfully used.</returns>
    public bool Use(UseObject user, PickableObject pickedObject)
    {
        bool matchingType = false;
        for (int i = 0; i < pickedObject.UsableObjectTypes.Count; i++)
        {
            if (pickedObject.UsableObjectTypes[i] == ObjectType) { matchingType = true; }
            if (Code != "" && Code != pickedObject.Code) { matchingType = false; }
        }

        if (!matchingType) { return false; }

        onUse.Invoke(user);
        return true;
    }
}

public enum UsableObjectType
{
    unusable = -1,

    environment = 0,
    ghostEnvironment = 1,
    humanEnvironment = 2,

    pickable = 10,
    ghostPickable = 11,
    humanPickable = 12,

    lockThing = 50,

    slot = 60,



}