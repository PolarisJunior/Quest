using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedMovement : MonoBehaviour
{
    public AnimationCurve animCurve;
    
    private float startTime;

    private float timeSinceStart;

    private Vector3 startPos;
    public Vector3 endPos;
    
    void Start()
    {
        animCurve.postWrapMode = WrapMode.PingPong;
        animCurve.preWrapMode = WrapMode.PingPong;

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float value = animCurve.Evaluate(timeSinceStart);
        transform.position = Vector3.Lerp(startPos, endPos, value);
        timeSinceStart += Time.deltaTime;
    }

    void OnEnable() {
        startTime = Time.time;
    }
}
