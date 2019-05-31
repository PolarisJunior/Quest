using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOffObserver : PObserver
{
    public Animator animator;

    public override void Run(string e) {
        animator.Play("Entry", 0, 0f);
        animator.speed = 0;
    }
}
