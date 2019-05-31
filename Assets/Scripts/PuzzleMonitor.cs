using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class PuzzleMonitor : MonoBehaviour
{
    public UnityEvent onPuzzleCompleted;
    
    public Dictionary<UnityEvent, bool> puzzleState = new Dictionary<UnityEvent, bool>();

    float timeElapsed = 0;
    bool timerStarted = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (timerStarted)
        {
            timeElapsed += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void StopTimer()
    {
        timerStarted = false;
    }

    public void ResetTimer()
    {
        timeElapsed = 0;
    }

    public void Reset()
    {
        foreach (var pair in puzzleState)
        {
            puzzleState[pair.Key] = false;
            CheckCompleted();
        }
    }

    public void Register(UnityEvent e)
    {
        puzzleState.Add(e, false);
        e.AddListener(delegate()
        {
            puzzleState[e] = true;
            CheckCompleted();
        });
    }

    public void CheckCompleted()
    {
        if (puzzleCompleted)
        {
            onPuzzleCompleted.Invoke();
        }
    }

    public void Hello()
    {
        Debug.Log("Hello: " + name);
    }

    public bool puzzleCompleted
    {
        get
        {
            foreach (var pair in puzzleState)
            {
                if (!pair.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
