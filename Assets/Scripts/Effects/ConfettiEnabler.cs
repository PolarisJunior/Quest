using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ConfettiEnabler : MonoBehaviour
{

    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var emission = ps.emission;
        emission.enabled = ConfettiController.confettiOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (ConfettiController.confettiOn) {
            var emission = ps.emission;
            emission.enabled = true;
            // stop simulating
            enabled = false;
        }
    }
}
