using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduledSpawn : MonoBehaviour
{
    // time after activation to start
    public float creationTime = 0;
    // Start is called before the first frame update
    [HideInInspector]
    public float elapsedTime;

    bool hasShown = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (!hasShown && elapsedTime >= creationTime) {
            PObject pObj = gameObject.GetComponent<PObject>();
            pObj.Alive();
            hasShown = true;
        }
    }

    void OnEnable() {
        // Debug.Log("scheduled spawn enabled");
    }


}
