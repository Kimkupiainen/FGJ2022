using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource effectPrefab;
    [SerializeField] private List<AudioEffectLink> effects = new List<AudioEffectLink>();

    public void Spawn()
    {
        Spawn(transform.position, effects[0].Clip);
    }
    public void Spawn(Vector3 point)
    {
        Spawn(point, effects[0].Clip);
    }
    public void Spawn(string effectName)
    {
        Spawn(transform.position, effectName);
    }
    public void Spawn(Vector3 point, string effectName)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            if (effects[i].Name == effectName)
            { Spawn(point, effects[i].Clip); }
        }
    }

    public void Spawn(Vector3 point, AudioClip clip)
    {
        Debug.Log("Spawning " + clip.name);
        AudioSource source = Instantiate(effectPrefab, point, Quaternion.identity);
        source.clip = clip;
        source.Play();
    }

    public void SpawnRandon() { SpawnRandom(transform.position); }
    public void SpawnRandom(Vector3 point)
    {
        Spawn(point, effects[Random.Range(0, effects.Count)].Clip);
    }

    [System.Serializable]
    public class AudioEffectLink
    {
        [SerializeField] private string name;
        public string Name { get => name; }
        [SerializeField] private AudioClip clip;
        public AudioClip Clip { get => clip; }
    }
}
