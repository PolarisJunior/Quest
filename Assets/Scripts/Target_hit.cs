using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Target_hit : MonoBehaviour
{
    public Material Glow;
    public Material def;

    public UnityEvent onHit;
    private bool canHit;
    private bool complete = false;

    void Start()
    {
        GetComponent<Renderer>().material = def;
        GetComponent<AudioSource>().playOnAwake = false;
    }
    void OnCollisionEnter(Collision col)
    {
        if (canHit)
        {
            playTarget();
            onHit.Invoke();
        }
    }

    void goBack()
    {
        GetComponent<Renderer>().material = def;
    }

    public void playTarget() {
        GetComponent<Renderer>().material = Glow;
        if (!complete)
        { 
            GetComponent<AudioSource>().Play();
        }
        Invoke("goBack", 0.2f);
    }

    public bool CanHit
    {
        get
        {
            return canHit;
        }
        set
        {
            canHit = value;
        }
     }

     public bool Complete
     {
        get
        {
            return complete;
        }
        set
        {
            complete = value;
        }
    }
}
