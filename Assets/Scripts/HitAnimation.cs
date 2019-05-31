    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimation : MonoBehaviour
{
    public float speed;

    public string animationName;
    Animation anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animation>();
        foreach (AnimationState state in anim)
        {
            state.speed = speed;
        }
    }

    void OnEnable() {
        anim.Play();
        Invoke("GoodbyeCruelWorld", anim.clip.length / speed);
    }   

    void GoodbyeCruelWorld() {
        gameObject.SetActive(false);
    }
}
