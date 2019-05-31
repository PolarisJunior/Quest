using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoShifter : MonoBehaviour
{
    public float tempo;

    public AudioSource[] sources;
    // Start is called before the first frame update
    void Start()
    {
        foreach (AudioSource source in sources)
        {
            // Turns on 3D (ish) sound
            source.spatialBlend = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (AudioSource source in sources)
        {
            source.pitch = tempo;
        }
    }

    public void enableLoop(int n)
    {
        if (n >= 0 && n < sources.Length)
        {
            sources[n].volume = 1;
        }
    }

    public void disableLoop(int n)
    {
        if (n >= 0 && n < sources.Length)
        {
            sources[n].volume = 0;
        }
    }

    public void setTempo(float tempo)
    {
        this.tempo = tempo;
    }
}
