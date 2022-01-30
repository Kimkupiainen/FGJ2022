using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramo : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip altClip;
    public void SwitchAudio()
    {
        AudioClip temp = altClip;
        altClip = source.clip;
        source.clip = temp;
    }
}
