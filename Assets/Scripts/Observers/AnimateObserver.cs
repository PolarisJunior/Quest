using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateObserver : PObserver
{
    public Animator animator;

    // Start is called before the first frame update
    public override void Run(string e) {
        Debug.Log("hit once");
        animator.speed = 1;
    }
}

