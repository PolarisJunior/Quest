using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapPosition : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = (leftHand.transform.position.x + rightHand.transform.position.x) / 2.0f;
        float y = (leftHand.transform.position.y + rightHand.transform.position.y) / 2.0f;
        float z = (leftHand.transform.position.z + rightHand.transform.position.z) / 2.0f;
        Vector3 temp = new Vector3(x, y, z);
        transform.position = temp;
    }
}
