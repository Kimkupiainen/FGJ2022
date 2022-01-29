using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class FPSCounter3D : FPSCounter
{
    [SerializeField] private TextMesh text;

    private void OnValidate()
    {
        if(text == null)
        { text = GetComponent<TextMesh>(); }
    }

    protected override void UpdateText(string output)
    {
        text.text = output;
    }
}
