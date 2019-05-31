/* using System.Collections;
using UnityEngine;
using UnityEngine.serialization;

// Generic controller for organizing events within puzzles

public class PuzzleController : MonoBehaviour
{
        [SerializeField] private UIFader p_CompletedFader;                  // fader in control of the UI for when the player completes the puzzle, if we want a fader?
        [SerializeField] private ParticleSystem p_Particles;                // The particle system that will play when the puzzle is completed (AJ will add shape particles)
        [SerializeField] private AudioSource puzzle_clip_start;                   // Puzzle clip audio source for start phase
        [SerializeField] private AudioSource puzzle_clip_main;                   // Puzzle clip audio source for main puzzle
        [SerializeField] private AudioSource puzzle_clip_complete;                   // Puzzle clip audio source for end
        [SerializeField] private CameraOrbit p_CameraOrbit;                 // This needs to be reset for each new game.


        private bool p_Running;                                             // Puzzle game running tracker.
        private bool p_Completed;                                           // Whether puzzle has been completed.


        public bool Playing { get { return p_Running; } }


        private void OnEnable ()
        {
            // any variable that responds actively to puzzle being finished += HandlePuzzleComplete;
        }


        private void OnDisable ()
        {
            // any variable that deactivates in response to puzzle being finished -= HandlePuzzleComplete;
        }


        private IEnumerator Start()
        {
            // reset/initiate puzzle 
            Restart();

            while (true)
            {
                // Keep looping through the Start, Play and End phases, waiting for each to finish.
                yield return StartCoroutine(StartPhase());
                yield return StartCoroutine(PlayPhase());
                yield return StartCoroutine(EndPhase());
            }
        }


        private IEnumerator StartPhase ()
        {
            // Insert tutorial/learning intro phase of the puzzle mechanic
            puzzle_clip_start.Play();
        }


        private IEnumerator PlayPhase()
        {
            // Main puzzle game phase
            p_Running = true;
            //main audio
            puzzle_clip_main.Play();

            // While the puzzle is running, loop the frame.
            while (p_Running)
            {
                yield return null;
            }



        private IEnumerator EndPhase()
        {
            // If the player completed the puzzle
            if (p_Completed)
            {
                // cue the shape particles!
                p_Particles.Play(true);
                puzzle_clip_complete.Play();

                // Wait for the particles to finish.
                yield return new WaitForSeconds(p_Particles.duration);

                // Wait for the completed UI to fade in.
                yield return StartCoroutine (p_CompletedFader.InteruptAndFadeIn ());
            }
            else
            {
                //handle non-completion, will vary with puzzle
            }


            // In order wait for the win and lose UI to fade out (only one should be faded in) then wait for the camera to fade out.
            yield return StartCoroutine (p_CompletedFader.InteruptAndFadeOut ());
            yield return StartCoroutine (p_CameraFade.BeginFadeOut(true));

            // Restart all the dependent scripts.
            Restart();

            // Wait for the screen tot fade back in.
            yield return StartCoroutine(p_CameraFade.BeginFadeIn(true));
        }


        private void Restart()
        {
            // Restart everything 
            p_CameraOrbit.Restart();
            p_Particles.Stop(true);
        }

        private void HandlePuzzleComplete()
        {
            // reset variables at end of puzzle phase
            p_Running = false;
            p_Completed = true;
        }
    }
} */