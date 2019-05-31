using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObserver : PObserver
{
    public float destroyDelay = 0;

    public override void Run(string e) {
        DoDestroy();
    }

    public void DoDestroy() {
        Destroy(gameObject, destroyDelay);
    }
}
