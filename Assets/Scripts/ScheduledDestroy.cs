using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduledDestroy : MonoBehaviour
{

    public float destroyTime;
    // Start is called before the first frame update
    private float elapsedTime;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (destroyTime > 0 && elapsedTime >= destroyTime) {
            Destroy(gameObject);
        }
    }

    void OnEnable() {
        // Debug.Log("Schedule Destroy enabled");
    }
}
