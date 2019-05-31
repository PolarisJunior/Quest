using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturntoOrig : MonoBehaviour
{
    public Vector3 location;

    void Start()
    {
        location = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("ComeBack", 3f);
    }
    private void ComeBack()
    {
        transform.position = location;
        
    }

}
