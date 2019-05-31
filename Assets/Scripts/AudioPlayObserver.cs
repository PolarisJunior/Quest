using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayObserver : PObserver
{

    public AudioSource source;
    

    public override void Run(string e) {
        source.Play();
    }
}
