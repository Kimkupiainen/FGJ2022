using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C7_Player : MonoBehaviour
{
    [SerializeField] private float duration = 1.0f;
    [SerializeField] private bool loop = true;
    [SerializeField] private bool backAndFort = false;
    [SerializeField] private bool playOnStart = true;
    [Space(20)]
    [SerializeField] private List<C7_Component> linkedComponents = new List<C7_Component>();
    [SerializeField] private UnityEvent onStart;
    [SerializeField] private UnityEvent onTurn;
    [SerializeField] private UnityEvent onEnd;

    public float Duration { get { return duration; } set { duration = value; } }
    public bool Loop { get { return loop; } set { loop = value; } }
    public bool BackAndFort { get { return backAndFort; } set { backAndFort = value; } }
    public List<C7_Component> LinkedComponents { get { return linkedComponents; } set { linkedComponents = value; } }
    public UnityEvent OnStart { get { return onStart; } }
    public UnityEvent OnTurn { get { return onTurn; } }
    public UnityEvent OnEnd { get { return onEnd; } }
    private float timer = 0.0f;
    private float direction = 1f;

    private C7_Player_Play_State state = C7_Player_Play_State.notPlaying;
    public C7_Player_Play_State State { get => state; private set => state = value; }

    private void OnValidate()
    {
        this.enabled = true;
    }

    private bool started = false;
    private void Start()
    {
        if (started) { return; }
        if (playOnStart) { Play(); }
        else { this.enabled = false; State = C7_Player_Play_State.notPlaying; }
    }

    private void Update()
    {
        timer += (Time.deltaTime / duration) * direction;

        if (direction > 0 && timer >= 1.0f)
        {
            if (backAndFort) { direction = -1f; timer = 1.0f - (timer - 1.0f); onTurn.Invoke(); }
            else
            {
                if (loop) { timer = timer - 1.0f; onTurn.Invoke(); }
                else { timer = 1.0f; Stop(); }
            }
        }
        else if (direction < 0 && timer <= 0.0f)
        {
            if (backAndFort && loop) { direction = 1f; timer *= -1; onTurn.Invoke(); }
            else
            {
                if (loop) { timer = 1.0f - (timer - 1.0f); onTurn.Invoke(); }
                else { timer = 0.0f; Stop(); }
            }
        }

        ForceToPoint(timer);
    }

    public void ForceToPoint(float point)
    {
        timer = point;
        for (int i = 0; i < linkedComponents.Count; i++)
        { linkedComponents[i].UpdateState(point); }
    }

    /// <summary>
    /// If paused, use Continue() instead. Unless restart is wanted.
    /// </summary>
    [EasyButtons.Button()]
    public void Play()
    {
        started = true;
        State = C7_Player_Play_State.playing;
        this.enabled = true;
        direction = 1f;
        timer = 0f;
        onStart.Invoke();
    }
    public void Pause()
    {
        State = C7_Player_Play_State.paused;
        this.enabled = false;
    }
    public void Continue()
    {
        State = C7_Player_Play_State.playing;
        this.enabled = true;
    }
    public void Stop()
    {
        State = C7_Player_Play_State.notPlaying;
        this.enabled = false;
        onEnd.Invoke();
    }

    public void ContinueOrPlay()
    {
        if (State == C7_Player_Play_State.paused) { Continue(); }
        else { Play(); }
    }

    public enum C7_Player_Play_State
    {
        notPlaying = 0,
        playing = 1,
        paused = 2,
    }
}
