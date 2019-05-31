using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class BoidParticleSystem : MonoBehaviour
{

    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
        var colorOverLifetime = ps.colorOverLifetime;
        Gradient grad = new Gradient();

        int numColors = 4;

        Color[] colors = ColorGenerator.GenerateColors(numColors);
        float delta = 1.0f / numColors;

        GradientColorKey[] colorKeys = new GradientColorKey[numColors];

        for (var i = 0; i < numColors; i++)
        {
            colorKeys[i] = new GradientColorKey(colors[i], (delta * (i + 1)));
        }

        GradientAlphaKey[] alphaKeys = {new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 0.5f), new GradientAlphaKey(0.0f, 1.0f)};


        grad.SetKeys(colorKeys, alphaKeys);

        colorOverLifetime.color = grad;
        ParticleSystem.MainModule mainModule = ps.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(colors[0]);
    }
}
