﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// @COMMENTEDOUT
public class Hittable : MonoBehaviour
{
    public uint hitsToUnlock;

    public UnityEvent onHitOnce;
    public UnityEvent onUnlock;
    public UnityEvent onPinched;
    public UnityEvent onTracked;

    public GameObject haptics;

    public bool inContact;

    public bool canHit;
    public bool canInteract;
    public bool preventRepeated = true;

    private bool isUnlocked = false;

    // keep track of hit counts
    [HideInInspector]
    public uint hitCount;

    // use hit flag to keep track of hits
    private bool hitFlag;



    void Start()
    {
        // haptics = GameObject.Find("/Haptics");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!isUnlocked)
            {
                Unlock();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (canHit)
        {
            if (preventRepeated)
            {
                canHit = false;
            }
            if (other.gameObject.tag == "DrumstickLeft") {
                // @COMMENTEDOUT
                // haptics.GetComponent<Haptics>().PulseLeft();
            } else if (other.gameObject.tag == "DrumstickRight")
            {
                // @COMMENTEDOUT
                // haptics.GetComponent<Haptics>().PulseRight();
            }
            onHitOnce.Invoke();
            hitCount++;
            
            if (hitCount == hitsToUnlock)
            {
                Unlock();
            }


            HitFlag = true;
        }
    }

    public void Unlock()
    {
        onUnlock.Invoke();
        isUnlocked = true;
    }

    void OnPinched()
    {
        if (canInteract)
        {
            onPinched.Invoke();
        }
    }

    void OnTracked()
    {
        if (canInteract)
        {
            onTracked.Invoke();
        }
    }



    public void StopHit()
    {
        canHit = false;
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

    // Resets the hit count if the hitflag is not set
    public void ResetIfHitFlagNotSet()
    {
        if (hitCount != 0)
        {
            //Play miss sound quietly?
        }
        if (!HitFlag)
        {
            HitCount = 0;
        }
    }

    public bool HitFlag
    {
        get
        {
            return hitFlag;
        }

        set
        {
            hitFlag = value;
        }
    }

    public uint HitCount
    {
        get
        {
            return hitCount;
        }

        set
        {
            hitCount = value;
        }
    }

    public float completion
    {
        get
        {
            return (float) hitCount / hitsToUnlock;

        }
    }
}
