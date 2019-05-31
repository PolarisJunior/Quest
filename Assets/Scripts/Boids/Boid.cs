using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    Flock flock;

    // public float minVelocity;

    // public float maxVelocity;

    // public float randomness;

    // public Rigidbody rigidBody;

    public float minScale = 1;
    public float maxScale = 1;

    public float steeringScale = 1.0f;
    public float alignmentScale = .5f;

    public Color[] colors;
    private GameObject chasee;

    float noiseOffset;


    // Start is called before the first frame update
    void Start()
    {
        steeringScale = 2.0f;
        // LayerMask mask = (1 << 4);
        gameObject.layer = LayerMask.NameToLayer("Boid");

        noiseOffset = Random.value * 10.0f;

        // float scale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), Random.Range(minScale, maxScale));

        Color color;

        // if (colors.Length > 0)
        // {
        //     int i = Random.Range(0, colors.Length);
        //     color = colors[(int)i];
        // }
        // else
        {
            color = ColorGenerator.GenerateColor();
        }

        float alpha = Random.Range(0.35f, .9f);
        color.a = alpha;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }

    Vector3 GetSeparationVector(Transform target)
    {
        // var diff = transform.position - target.transform.position;
        var diff = transform.position - target.position;
        var diffLen = diff.magnitude;
        var scaler = Mathf.Clamp01(1.0f - diffLen / flock.neighborRadius);
        return diff * (scaler / diffLen);
    }

    void Update()
    {
        var currentPos = transform.position;
        var currentRot = transform.rotation;

        var noise = Mathf.PerlinNoise(Time.time, noiseOffset) * 2.0f - 1.0f;
        var speed = flock.flockSpeed * (1.0f + noise);


        var separation = Vector3.zero;
        // flock alignment

        // these both work pretty well
        var alignment = transform.forward;
        // var alignment = flock.transform.forward;
        // var alignment = flock.flockAlignment;
        // var alignment = chasee.transform.position - transform.position;
        // var alignment = Vector3.zero;
        
        // center of mass
        // var cohesion = flock.transform.position;
        // var cohesion = flock.flockCenter;
        var cohesion = transform.position;
        // var cohesion = chasee.transform.position;
        // var cohesion = Vector3.zero;

        // target steering
        var steering = (chasee.transform.position - transform.position).normalized;

        var nearbyBoids = Physics.OverlapSphere(currentPos, flock.neighborRadius, flock.searchLayer);
        // var nearbyBoids = Physics.OverlapSphere(currentPos, flock.neighborRadius);

        bool alone = true;
        {
            foreach (var boid in nearbyBoids)
            {
                if (boid.gameObject == gameObject) continue;

                // Boid b = boid.GetComponent<Boid>();
                // if (b == null) {
                //     Debug.Log("wrong");
                // }

                var t = boid.transform;
                separation += GetSeparationVector(t);
                alignment += t.forward;
                cohesion += t.position;
                alone = false;
            }
        }


        var avg = 1.0f / nearbyBoids.Length;
        alignment *= avg;
        cohesion *= avg;
        cohesion = (cohesion - currentPos).normalized;

        // if (alone && Vector3.Distance(transform.position, chasee.transform.position) > 40) {
        //     Debug.Log("yeah " + alignment + " " + cohesion + " steering: " + steering + " sep: " + separation);
        //     gameObject.name = "far away";
        // }

        var off = new Vector3(Random.Range(0.0f, 0.05f), Random.Range(0.0f, 0.05f), Random.Range(0.0f, 0.05f));
        // var direction = separation + alignment + cohesion;
        var direction = separation + alignment * alignmentScale + cohesion + (steering * steeringScale) + off;
        var rotation = Quaternion.FromToRotation(Vector3.forward, direction.normalized);
        if (rotation != currentRot)
        {
            var ip = Mathf.Exp(-flock.rotationCoef * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(rotation, currentRot, ip);
            // transform.rotation = rotation;
        }

        transform.position = currentPos + transform.forward * (speed * Time.deltaTime);

    }

    public void SetFlock(Flock flock)
    {
        this.flock = flock;

        // randomness = flock.randomness;
        chasee = flock.chasee;
    }
}
