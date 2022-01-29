using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor.Events;
#endif

public static class ExtensionsEvents
{
    /// <summary>
    /// Adds an action to an event. Removes duplicates. Editor only function, do not call run time.
    /// </summary>
    /// <param name="e">Event which the action is added to</param>
    /// <param name="action">Action which is added to the event</param>
    public static void OnValidateOnlyAddEvent(this UnityEvent e, UnityAction action)
    {
#if UNITY_EDITOR
        UnityEventTools.RemovePersistentListener(e, action);
        UnityEventTools.AddPersistentListener(e, action);
#endif
    }

    public static void OnValidateOnlyAddEvent<T>(this UnityEvent<T> e, UnityAction<T> action)
    {
#if UNITY_EDITOR
        UnityEventTools.RemovePersistentListener(e, action);
        UnityEventTools.AddPersistentListener(e, action);
#endif
    }
}

[System.Serializable]
public class UnityEventFloat : UnityEvent<float> { }
[System.Serializable]
public class UnityEventInt : UnityEvent<int> { }
[System.Serializable]
public class UnityEventBool : UnityEvent<bool> { }
[System.Serializable]
public class UnityEventString : UnityEvent<string> { }
[System.Serializable]
public class UnityEventGameObject : UnityEvent<GameObject> { }
[System.Serializable]
public class UnityEventTransform : UnityEvent<Transform> { }
[System.Serializable]
public class UnityEventVector3 : UnityEvent<Vector3> { }
[System.Serializable]
public class UnityEventVector2 : UnityEvent<Vector2> { }