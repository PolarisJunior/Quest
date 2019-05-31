using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;


/* 
    Handles multiple puzzles needing to be started
    and completed within a certain time window
 */
public class JointPuzzle : MonoBehaviour
{
    public float endWindow = 2;

    public float startWindow = 2;

    public List<UnityEvent> endEvents = new List<UnityEvent>();

    public List<UnityEvent> startEvents = new List<UnityEvent>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Register(UnityEvent start, UnityEvent end) {
        
    }
}
