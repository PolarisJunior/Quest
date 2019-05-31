using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{

    public Material pulseOn;
    public Material pulseOff;
    public float pulseInterval;

    public bool enablePulse;

    private void Start()
    {
        Invoke("PulseOn", pulseInterval);
    }

    private void PulseOn()
    {
        if (enablePulse)
        {
            GetComponent<Renderer>().material = pulseOn;
        }
        Invoke("PulseOff", pulseInterval);
    }

    private void PulseOff()
    {
        if (enablePulse)
        {
            GetComponent<Renderer>().material = pulseOff;
        }
        Invoke("PulseOn", pulseInterval);
    }
}
