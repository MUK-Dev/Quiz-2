using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;

    private float score = 0;

    private void Awake()
    {
        Instance = this;
        UpdateScore();
    }

    public void IncreaseScore()
    {
        score += 25;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
