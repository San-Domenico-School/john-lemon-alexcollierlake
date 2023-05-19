using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private float fadeDuration;
    private float displayImageDuration;
    private float timer;
    private bool isPlayerAtExit;


    // Start is called before the first frame update
    void Start()
    {
        fadeDuration = 1.0f;
        displayImageDuration = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }






}
