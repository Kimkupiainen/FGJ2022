using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float defaultDuration = 1f;
    [SerializeField] private bool disableOnEnd = true;
    [SerializeField] private UnityEventFloat onTimerUpdateEvent = new UnityEventFloat();
    [SerializeField] private UnityEvent onTimerEndEvent = new UnityEvent();

    private float time = 0f;
    private float Timee
    {
        get { return time; }
        set
        {
            time = value;
            if (time <= 0)
            {
                time = 0f;
                onTimerEndEvent.Invoke();
                if (disableOnEnd) { this.enabled = false; }
            }
            onTimerUpdateEvent.Invoke(1f - time);
        }
    }
    private float TargetDuration { get; set; }

    void Update()
    {
        Timee -= Time.deltaTime / TargetDuration;
    }

    public void Play()
    {
        TargetDuration = defaultDuration;
        Timee = 1f;
        this.enabled = true;
    }
    public void Play(float customDuration)
    {
        TargetDuration = customDuration;
        Timee = 1f;
        this.enabled = true;
    }
    public void Stop()
    {
        this.enabled = false;
    }
}