using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter() {
        // Debug.Log("trigger entered");
    }

    void OnCollisionEnter() {
        // Debug.Log("collision enter");
    }

    void OnTriggerStay(Collider other) {
        // Debug.Log("trigger stay " + other.gameObject + " " + other.gameObject.layer);

    }

    void OnCollisionStay() {
        // Debug.Log("collision stay");
    }
}
