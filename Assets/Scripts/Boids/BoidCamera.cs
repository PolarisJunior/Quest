using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidCamera : MonoBehaviour
{

    public GameObject target;
    public float placementRadius = 20;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            
            target.transform.position = gameObject.transform.position + ray.direction * placementRadius;
        }
    }
}
