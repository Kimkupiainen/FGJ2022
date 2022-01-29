using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public abstract class FPSCounter : MonoBehaviour
{
    [Range(1, 100)]
    [Tooltip("Calculate average FPS of past 'frameCount'")]
    [SerializeField] private int frameCount = 10;

    private List<float> frames = new List<float>();
    private float average = 0f;

    void Start()
    {
        for (int i = 0; i < frameCount; i++) { frames.Add(0f); }
    }

    void Update()
    {
        frames.Add(1 / Time.deltaTime);
        frames.RemoveAt(0);

        average = 0f;
        foreach (float f in frames) { average += f; }
        average /= frames.Count;

        UpdateText("FPS: " + Mathf.RoundToInt(average));
    }

    protected abstract void UpdateText(string output);
}
