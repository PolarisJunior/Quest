using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PianoDestinationActions : MonoBehaviour
{
    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newScale;

    // public UnityEvent startPuzzle;

    public void Arrive()
    {
        gameObject.SetActive(true);
    }

    public void Depart()
    {
        transform.localPosition = newPosition;
        transform.rotation = newRotation;
        transform.localScale = newScale;
    }
}
