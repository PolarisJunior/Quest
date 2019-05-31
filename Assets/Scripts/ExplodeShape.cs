/* 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Activate an explosion Particle Effect on shapes
public class ExplodeShape : TriggerEvent {

    ParticleSystem boom;
    public override void Activate()
    {
        boom.Play();
    }

    public override void Activate(bool state)
    {
        if(state)
            Activate();
    }

    public override void Activate(int state)
    {
        Activate(state != 0);
    }

    // Use this for initialization
    void Start () {
        boom = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
} */