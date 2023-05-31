using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/* This will manage the score of the game.
     * 
     * Alexndra Collier-Lake
     * 05/31/2023
     */
public class ScoreManager : MonoBehaviour
{

    [SerializeField] private int score;
    [SerializeField] private TMP_Text scoreText;

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        
    }
}
