using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenameByPrefab : MonoBehaviour
{
    /// <summary>
    /// Renames the object to match it's prefab name
    /// </summary>
    private void OnValidate()
    {
#if UNITY_EDITOR
        if (UnityEditor.PrefabUtility.GetCorrespondingObjectFromSource(gameObject) != null)
        { gameObject.name = UnityEditor.PrefabUtility.GetCorrespondingObjectFromSource(gameObject).name; }
        this.DestroyInEditor();
#endif
    }
}
