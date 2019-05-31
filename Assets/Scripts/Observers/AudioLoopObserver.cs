using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoopObserver : PObserver
{
    public AudioSourceLoop source;

    public void Start() {
    }

    public override void Run(string e) {
        source.PlayLooping();
    }
}
