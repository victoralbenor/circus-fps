using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public ScoreKeeper ScoreKeeper;

    private int m_Score;
    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        // Destroy itself if there is already another instance

        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        m_Score = 0;
    }

    public void AddScore(int amount)
    {
        m_Score += amount;
        ScoreText.text = "Score: " + m_Score;
    }

    public void SaveScore()
    {
        ScoreKeeper.SubmitScore(m_Score);
    }
}