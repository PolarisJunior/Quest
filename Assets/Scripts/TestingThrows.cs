using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class TestingThrows : MonoBehaviour
    {
        public Material Glow;
        public Material Default;
        //public Vector3 velocity_lh;
        //public Vector3 velocity_rh;
       // public GameObject lhand;
        //public GameObject rhand;
       
        public AudioClip chord1;
        bool hitTarget = false;

        // Start is called before the first frame update
        void Start()
        {
            //GetComponent<Renderer>().enabled = true;
            //chord1 = GameObject.FindWithTag("t1").GetComponent<AudioClip>();
            GetComponent<AudioSource>().clip = chord1;
        }

        // Update is called once per frame
        /*void Update()
        {
            velocity_lh = lhand.GetComponent<VelocityEstimator>().GetVelocityEstimate();
            velocity_rh = rhand.GetComponent<VelocityEstimator>().GetVelocityEstimate();
        }*/
        void OnCollisionEnter(Collision col)
        {
            hitTarget = !hitTarget;
            if (hitTarget)
            {
                GetComponent<Renderer>().material = Glow;
                //chord1.volume = velocity_rh.magnitude / 2;
                //Glow.SetFloat("_Color", chord1.volume);
                GetComponent<AudioSource>().Play();
                Invoke("Glownow", 0);
                
                Invoke("goBack", 0.1f);
            }
            /*if (hitTarget && col.gameObject.tag == "t2")
            {
                chord2.volume = velocity_rh.magnitude / 2;
                GetComponent<Renderer>().material = Glow;
                Glow.SetFloat("intensity", chord2.volume);
                chord2.Play();
                
                Invoke("goBack", 0.1f);
            }
            if (hitTarget && col.gameObject.tag == "t3")
            {
                chord3.volume = velocity_rh.magnitude / 2;
                Glow.SetFloat("intensity", chord3.volume);
                chord3.Play();
                GetComponent<Renderer>().material = Glow;
                Invoke("goBack", 0.1f);
            }*/
        }

        void goBack()
        {
            GetComponent<Renderer>().material = Default;
            hitTarget = !hitTarget;
            //GetComponent<Renderer>().enabled = false;
    }

        public void PlaynFlash(float d)
        {
        hitTarget = !hitTarget;
        GetComponent<AudioSource>().PlayDelayed(d);
        Invoke("Glownow", d);
        Invoke("goBack", 0.2f);
        }

        private void Glownow()
    {
        GetComponent<Renderer>().material = Glow;
    }
}