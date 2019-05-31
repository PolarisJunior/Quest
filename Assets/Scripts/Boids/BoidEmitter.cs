using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BoidEmitter : MonoBehaviour
{
    // The flock the boids will join
    public Flock flock;

    public float emitRadius = 3;

    void Start()
    {
        if (flock == null) {
            flock = GameObject.Find("Flock").GetComponent<Flock>();
        }
    }

    public void EmitBoid() {
        EmitBoids(1);
    }

    public void EmitBoids(int n) {
        for (var i = 0; i < n; i++) {
            flock.AddBoid(transform.position + Random.insideUnitSphere * emitRadius);
        }
    }

}
