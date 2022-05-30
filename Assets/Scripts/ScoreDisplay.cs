using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public ScoreKeeper ScoreKeeper;
    public TextMeshProUGUI LastScore;
    public TextMeshProUGUI[] ScoreRanking;

    private void Start()
    {
        LastScore.text = "L. " + ScoreKeeper.LastScore;
        for (var i = 0; i < ScoreKeeper.HighScores.Count; i++)
        {
            ScoreRanking[i].text = (i+1) + ". " + ScoreKeeper.HighScores[i];
        }
    }
}
