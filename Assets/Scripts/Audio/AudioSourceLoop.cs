using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceLoop : MonoBehaviour
{
    public AudioSource source;
    public BeatInfo beatInfo;

    public float delay = 1;
    public float startDelay = 0f;


    public bool isPlaying;

    public bool playOnStart;

    private int beatIndex = 0;

    void Start()
    {
        if (playOnStart)
        {
            Invoke("PlayLooping", startDelay);
        }
    }

    public void PlayOnce()
    {
        source.Play();
    }

    public void PlayLooping()
    {
        isPlaying = true;

        if (beatInfo == null)
        {
            InvokeRepeating("PlayOnce", 0, delay);
        }
        else
        {
            bool shouldPlay = beatInfo.beats[beatIndex];
            if (shouldPlay) {
                PlayOnce();
            }
            beatIndex = (beatIndex + 1) % beatInfo.numBeats;
            //Invoke("PlayLooping", beatInfo.beatTime);
        }
    }

    public void StopLooping()
    {
        isPlaying = false;
        CancelInvoke();
    }

    public float Delay
    {
        get
        {
            return delay;
        }

        set
        {
            if (isPlaying)
            {
                StopLooping();
                delay = value;
                PlayLooping();
            }
        }
    }

    public float volume
    {
        get
        {
            return source.volume;
        }

        set
        {
            source.volume = value;
        }
    }
}
