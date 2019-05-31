using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCamera : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~(1 << 2)))
            {
                Collider collider = hit.collider;
                collider.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
