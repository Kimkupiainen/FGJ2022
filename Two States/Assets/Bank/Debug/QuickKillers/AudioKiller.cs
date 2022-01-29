using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioKiller : MonoBehaviour
{
    private AudioSource aSource;
    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.Play();
    }
    private void Update()
    {
        if (!aSource.isPlaying) { Destroy(gameObject); }
    }
}
