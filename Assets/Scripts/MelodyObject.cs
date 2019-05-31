using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodyObject : MonoBehaviour
{

    public AudioClip loopClip;

    public Material windowOnMat;

    public Material windowOffMat;


    // mat to use while successfully following
    public Material trackingMat;

    // mat to use after failed
    public Material failMat;

    public PathBeat pathBeat;

    // only for determining when it starts currently
    public BeatInfo beatInfo;

    
    public float windowLength = 1f;
    public bool unlocked = false;

    public float beatOffset = 0;

    private AudioSource loopSource;
    private Collider coll;
    private MeshRenderer rend;

    private Hittable hittable;

    private bool windowStatus = false;


    void Awake()
    {
        coll = GetComponent<Collider>();
        rend = GetComponent<MeshRenderer>();
        loopSource = GetComponent<AudioSource>();
        rend.material = windowOffMat;

        // loopSource.clip = loopClip;
        // loopSource.pitch = loopClip.length / MasterLoop.loopTime;
        // loopSource.spatialBlend = 1.0f;
        // loopSource.clip = loopClip;

        hittable = GetComponent<Hittable>();
    }

    void Start()
    {
        hittable.canInteract = false;
        if (gameObject.activeInHierarchy)
        {
            rend.enabled = true;
        }

        // right now just hardcode the default masterloop time of 4.0f
        // float delta = 4.0f / beatInfo.numBeats;
        // int i = 0;

        // find the first beat and use that as the offset
        // foreach (var b in beatInfo.beats) {
        //     if (b) {
        //         break;
        //     }
        //     i++;
        // }

        // when using beat infos
        // beatOffset = i * delta;
    }

    public void NewLoop()
    {
        if (gameObject.activeInHierarchy)
        {
            // just keep looping if unlocked
            if (unlocked)
            {
                pathBeat.Invoke("ResetPosition", beatOffset);
            }
            
            // if still locked and not moving then handle the window indicator
            Invoke("WindowOn", beatOffset);
            Invoke("WindowOff", windowLength + beatOffset);
        }


        // loopSource.Play();
        // Invoke("StartWindow", MasterLoop.loopTime * startTime);
        // Invoke("StartPlay", MasterLoop.loopTime * (startTime + windowLength));
        // Invoke("EndPlay", MasterLoop.loopTime * endTime);
    }

    public void WindowOn()
    {
        // we need to keep the window status up to date incase the player fails
        windowStatus = true;
        if (!pathBeat.moving)
        {
            rend.material = windowOnMat;
            hittable.canInteract = true;
        }

    }

    public void WindowOff()
    {
        windowStatus = false;

        // only if  not moving
        if (!pathBeat.moving)
        {
            rend.material = windowOffMat;
            hittable.canInteract = false;
        }
    }

    public Material GetWindowMaterial()
    {
        return windowStatus ? windowOnMat : windowOffMat;
    }

    public void UnlockObject()
    {
        unlocked = true;
    }

    public void ObjectFailed()
    {
        pathBeat.Reset();
        rend.material = GetWindowMaterial();
    }

}