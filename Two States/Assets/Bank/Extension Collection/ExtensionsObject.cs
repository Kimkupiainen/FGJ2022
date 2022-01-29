using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsObject
{
    /// <summary>
    /// EDITOR ONLY ! Destroy object non-runtime, OnValidate use.
    /// </summary>
    public static void DestroyInEditor(this Object obj)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.delayCall += () => { Object.DestroyImmediate(obj); };
#endif
    }

    /// <summary>
    /// If GetComponent is unable to find the Component, tries to find from scene
    /// </summary>
    static public T GetOrFindComponent<T>(this GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>() ?? Object.FindObjectOfType<T>();
    }
}