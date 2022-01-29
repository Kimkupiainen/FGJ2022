using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSCounterUI : FPSCounter
{
    [SerializeField] private Text text;

    private void OnValidate()
    {
        if (text == null)
        { text = GetComponent<Text>(); }
    }

    protected override void UpdateText(string output)
    {
        text.text = output;
    }
}
