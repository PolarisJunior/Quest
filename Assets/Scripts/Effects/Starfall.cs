using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfall : MonoBehaviour
{

    public float spawnTime = 0.2f;
    public float spawnRadius = 1;

    public float torqueIntensity = 1000;

    public Color[] colors;
    
    // star needs gravity enabled
    public GameObject[] starPrefabs;

    public void RandomSpawnStar() {
        Vector2 v = Random.insideUnitCircle;
        while (v == Vector2.zero) {
            // edge case
            v = Random.insideUnitCircle;
        }

        v = v.normalized * spawnRadius;

        Vector3 pos = new Vector3(v.x, this.transform.position.y + (Random.value * 50), v.y);
        GameObject prefab = starPrefabs[Random.Range(0, starPrefabs.Length)];
        GameObject go = Instantiate(prefab, pos, Random.rotationUniform);
        go.transform.parent = transform;
        Rigidbody rigidBody = go.GetComponent<Rigidbody>();
        rigidBody.AddRelativeTorque(new Vector3(Random.value, Random.value, Random.value).normalized * torqueIntensity);

        // var c = colors[(int)Random.Range(0, colors.Length)];
        // go.GetComponent<Renderer>().material.SetColor("_EmissionColor", c); 
    }

    void OnEnable()
    {
        InvokeRepeating("RandomSpawnStar", spawnTime, spawnTime);
        

    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
