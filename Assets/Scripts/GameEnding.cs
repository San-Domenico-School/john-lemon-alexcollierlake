using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* This script will be used to toggle the alpha property 
 * of the ExitImageBackground when the player passes through 
 * the GameEndingTrigger and that the script is a component 
 * of the GameEndingTrigger.  
 * 
 * Alexandra Collier-Lake
 * 05/19/2023
 */
public class GameEnding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private CanvasGroup caughtBackgroundImageCanvasGroup;
    [SerializeField] private AudioSource exitAudio;
    [SerializeField] private AudioSource caughtAudio;
    private bool hasAudioPlayed;


    private float fadeDuration = 1.0f;
    private float displayImageDuration = 1.0f;
    private float timer;
    private bool isPlayerAtExit;
    private bool isPlayerCaught;



    // Checks if player has triggered caught or exit, then restarts or ends game.
    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }


    void EndLevel(CanvasGroup image, bool restartGame, AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;

        image.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if (restartGame)
            {
     
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }


    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }





}
