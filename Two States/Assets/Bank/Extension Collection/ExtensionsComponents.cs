using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsComponent
{
    /// <summary>
    /// Gets and sets reference to a component of the type if the reference is null
    /// </summary>
    public static void ValidateComponent<T>(this Component obj, ref T component) where T : Component
    {
        if (component != null) { return; }
        component = obj.gameObject.GetComponent<T>();
    }

    /// <summary>
    /// Gets and sets reference to a component of the type if the reference is null. Checks childrens also.
    /// </summary>
    public static void ValidateComponentInChildren<T>(this Component obj, ref T component) where T : Component
    {
        if (component != null) { return; }
        component = obj.gameObject.GetComponentInChildren<T>();
    }

    /// <summary>
    /// Gets and sets reference to a component of the type by the name of the gameobject if the reference is null. Checks childrens also.
    /// </summary>
    public static void ValidateComponentInChildren<T>(this Component obj, ref T component, string objectName) where T : Component
    {
        if (component != null) { return; }

        foreach (T finding in obj.gameObject.GetComponentsInChildren<T>())
        {
            if (finding.gameObject.name == objectName)
            { component = finding; }
        }

        //  component = obj.gameObject.GetComponentsInChildren<T>().Where(comp => comp.gameObject.name == objectName) as T;
    }

    /// <summary>
    /// Gets and sets reference to a component of the type by the name of the gameobject if the reference is null. Checks whole scene.
    /// </summary>
    public static void ValidateComponentInScene<T>(this Component obj, ref T component, string objectName) where T : Component
    {
        if (component != null) { return; }

        foreach (T sceneObj in UnityEngine.Object.FindObjectsOfType(typeof(T)))
        {
            if (sceneObj.name == objectName)
            {
                component = sceneObj;
                return;
            }
        }
    }
}
