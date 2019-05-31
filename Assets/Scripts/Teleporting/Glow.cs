using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class Glow : MonoBehaviour
    {
        public Material glowMaterial;
        public float blinkFreq = 1f;

        private Material originalMaterial;
        private bool blink;

        void Awake()
        {
            originalMaterial = GetComponent<Renderer>().material;
        }

        public void GlowBlinkOn()
        {
            blink = true;
            StartCoroutine(GlowBlink()); 
        }

        public void GlowBlinkOff()
        {
            blink = false;
        }

        private IEnumerator GlowBlink()
        {
            while (blink)
            {
                GlowOn();
                yield return new WaitForSeconds(blinkFreq);
                GlowOff();
                yield return new WaitForSeconds(blinkFreq);
            }
        }

        public void GlowOn()
        {
            originalMaterial = GetComponent<Renderer>().material;
            GetComponent<Renderer>().material = glowMaterial;
        }

        public void GlowOff()
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}
