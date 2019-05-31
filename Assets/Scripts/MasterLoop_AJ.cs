using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MasterLoop_AJ : MonoBehaviour
{
    //public UnityEvent onNewLoop;
    //public UnityEvent unlockedLoop;
    public AudioClip pianoLoop;
    public static float loopTime = 4f;

    public static float unitLoopTime = 4f; //The 'default' time for one loop
    
    public static float delay = .3f;
    // Start is called before the first frame update
    private TestingThrows t;
    public int numTargets = 3;
    public GameObject[] Targets;

    private void Awake()
    {
        GetComponent<AudioSource>().clip = pianoLoop;
        Invoke("Tutorial", 5f);
    }
    /*private void OnEnable()
    {
        if (CheckUnlocked())
        {
            Invoke("UnlockedLoop", delay);
        }     

        else
        {
            Invoke("NewLoop", delay);
        }
    }

    void NewLoop()
    {
        onNewLoop.Invoke();
        Invoke("NewLoop", loopTime);
    }
    void UnlockedLoop()
    {
        unlockedLoop.Invoke();
        Invoke("UnlockedLoop", loopTime);
    }
    private bool CheckUnlocked()
    {
        if (Targets[0].GetComponent<BeatBlinkController>().unlocked && Targets[1].GetComponent<BeatBlinkController>().unlocked && Targets[2].GetComponent<BeatBlinkController>().unlocked && Targets[3].GetComponent<BeatBlinkController>().unlocked)
        {
            return true;
        }
        else
        {
            return false;
        }     
    }*/
    private void Tutorial()
    {
        GetComponent<AudioSource>().Play();
        Targets[0].GetComponent<TestingThrows>().PlaynFlash(10f);
        Targets[0].GetComponent<TestingThrows>().PlaynFlash(10.2f);
        Targets[1].GetComponent<TestingThrows>().PlaynFlash(10.3f);
        Targets[1].GetComponent<TestingThrows>().PlaynFlash(10.4f);
        Targets[2].GetComponent<TestingThrows>().PlaynFlash(10.5f);
        Targets[2].GetComponent<TestingThrows>().PlaynFlash(10.6f);

        /*Targets[0].GetComponent<AudioSource>().PlayDelayed(5f);
        Targets[0].GetComponent<AudioSource>().PlayDelayed(5.2f);
        Targets[1].GetComponent<AudioSource>().PlayDelayed(5.3f);
        Targets[1].GetComponent<AudioSource>().PlayDelayed(5.4f);
        Targets[2].GetComponent<AudioSource>().PlayDelayed(5.5f);
        Targets[2].GetComponent<AudioSource>().PlayDelayed(5.6f);
        Targets[2].GetComponent<AudioSource>().PlayDelayed(5.7f);*/
    }
}
