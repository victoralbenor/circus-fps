using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public ScoreKeeper ScoreKeeper;

    private int m_Score;

    void Start() {
        m_Score = 0;
    }

    public void AddScore(int amount) {
        m_Score += amount;
    }

    public void SaveScore() {
        ScoreKeeper.SubmitScore(m_Score);
    }
}