using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scores", menuName = "ScriptableObjects/ScoreManagerScriptableObject", order = 1)]
public class ScoreKeeper : ScriptableObject
{
    public List<int> HighScores;
    public int HighScoresLength;
    public int LastScore;

    public void SubmitScore(int score)
    {
        LastScore = score;

        if (score <= HighScores[HighScoresLength]) return;
        // If current score is enough to make the rank, add it, sort the rank and remove exceeding scores
        HighScores.Add(score);
        HighScores.Sort();
        if (HighScores.Count > HighScoresLength)
            HighScores.RemoveRange(HighScoresLength, HighScores.Count - HighScoresLength);
    }
}