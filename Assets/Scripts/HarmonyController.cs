using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HarmonyController : MonoBehaviour
{
    public GameObject[] dots;
    public UnityEvent onCompletePuzzle;

    /*To make puzzle sequential (only do one chord 
    at a time), maybe have an array of audio sources and an
    index into the array. Use the chordComplete flag to determine
    if chord is complete, and if so, then loop that audio source
    and incrament the index. If get to end of the array, then have completed 
    the puzzle. Note we will use same audio sources 
    when player is completing the puzzle, just turn down the volume 
    if they mess up*/

    // public AudioSource[] chords;
    // private int audioIndex = 0;

    private BeatInfo beatInfo;
    private LineRenderer lineRenderer;

    private int start;
    private int end;
    private int prevStart;
    private float distance;
    private float speed;
    private float counter;

    private int beatIndex = -1;
    private bool waitForLoop = false;
    private bool notePlaying = false;

    private bool chordComplete = false;
    private bool puzzleComplete = false;

    private void Awake()
    {
        beatInfo = transform.Find("BeatInfo").GetComponent<BeatInfo>();
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;

        start = 0;
        end = -1;
        prevStart = -1;
    }

    private void OnEnable()
    {
        waitForLoop = true;
        RunHarmony();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void NewLoop()
    {
        if (!puzzleComplete)
        {
            beatIndex = -1;
            start = 0;
            end = -1;
            waitForLoop = false;
        }
        else
        {
            onCompletePuzzle.Invoke();
        }

    }

    void Update()
    {
        if (!waitForLoop)
        {
            if (start == -1 && prevStart != -1)
            {
                counter = 0;
                // stop glowing prevStart
            } 
            else if (counter < distance && end != -1)
            {
                counter += 0.1f / speed;
                float x = Mathf.Lerp(0, distance, counter);

                Vector3 startPos = dots[start].transform.position;
                Vector3 endPos = dots[end].transform.position;

                Vector3 pointOnLine = x * Vector3.Normalize(endPos - startPos) + startPos;

                lineRenderer.SetPosition(1, pointOnLine);
            }
        }
    }

    private void RunHarmony()
    {
        if (!waitForLoop)
        {
            int nextNote = beatInfo.notes[(beatIndex + 1) % beatInfo.notes.Length];
            beatIndex++;

            if (nextNote == 1)
            {
                // Stop glowing previous dots (with delay)
                if (start != -1 && end != -1)
                {
                    prevStart = start;
                    start = -1;
                }

                // Set up next line animation
                if (beatIndex != beatInfo.beats.Length - 2)
                {
                    if (end != -1)
                    {
                        start = end;
                    }
                    end = Random.Range(1, dots.Length);

                    distance = Vector3.Distance(dots[start].transform.position, dots[end].transform.position);
                    int noteLength = beatInfo.notes[(beatIndex + 2) % beatInfo.notes.Length];

                    speed = distance / (beatInfo.beatTime * noteLength);

                    lineRenderer.SetPosition(0, dots[start].transform.position);
                    lineRenderer.SetPosition(1, dots[start].transform.position);
                }
            }
        }

        if (beatIndex < beatInfo.beats.Length)
        {
            Invoke("RunHarmony", beatInfo.beatTime);
        }
    }

    public void ResetChord()
    {
        NewLoop();
        waitForLoop = true;
    }
}
