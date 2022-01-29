using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnEvent<T>
{
    [SerializeField] private List<Event<T>> activeEvents = new List<Event<T>>();

    public void Invoke(OnEventType occurance, T parameter)
    {
        for (int i = 0; i < activeEvents.Count; i++)
        {
            if (activeEvents[i].Occurance == occurance || activeEvents[i].Occurance == OnEventType.OnAny)
            { activeEvents[i].Invoke(parameter); }
        }
    }

    /// <summary>
    /// Return OnAny only if occurance set to OnAny
    /// </summary>
    public UnityEvent<T> GetFirstEvent(OnEventType occurance = OnEventType.OnAny)
    {
        for (int i = 0; i < activeEvents.Count; i++)
        { if (activeEvents[i].Occurance == occurance) { return activeEvents[i].Action; } }
        return null;
    }
}

[System.Serializable]
public class OnEvent
{
    [SerializeField] private List<Event> activeEvents = new List<Event>();

    public void Invoke(OnEventType occurance)
    {
        for (int i = 0; i < activeEvents.Count; i++)
        {
            if (activeEvents[i].Occurance == occurance || activeEvents[i].Occurance == OnEventType.OnAny)
            { activeEvents[i].Invoke(); }
        }
    }

    /// <summary>
    /// Return OnAny only if occurance set to OnAny
    /// </summary>
    public UnityEvent GetFirstEvent(OnEventType occurance = OnEventType.OnAny)
    {
        for (int i = 0; i < activeEvents.Count; i++)
        { if (activeEvents[i].Occurance == occurance) { return activeEvents[i].Action; } }
        return null;
    }
}

[System.Serializable]
public class Event<T>
{
    [SerializeField] private OnEventType occurance = OnEventType.OnAny;
    public OnEventType Occurance { get => occurance; }

    [SerializeField] private UnityEvent<T> action;
    public UnityEvent<T> Action { get => action; }

    public void Invoke(T parameter)
    {
        Action.Invoke(parameter);
    }
}

[System.Serializable]
public class Event
{
    [SerializeField] private OnEventType occurance = OnEventType.OnAny;
    public OnEventType Occurance { get => occurance; }

    [SerializeField] private UnityEvent action;
    public UnityEvent Action { get => action; }

    public void Invoke()
    {
        Action.Invoke();
    }
}

public enum OnEventType
{
    OnAny = 0,

    OnTryUse = 29,
    OnUse = 30,
    OnUnusable = 31,
    OnNoHit = 32,

    OnPickup = 40,
    OnDrop = 41,
}