using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int totalScore;

    public static Scoreboard instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        scoreText.text = "Score: " + totalScore.ToString();

        SetScoreColor();
    }

    public void AddScore(int score)
    {
        totalScore += score;
    }

    public void DeductScore(int score)
    {
        totalScore -= score;
    }

    void SetScoreColor()
    {
        if (totalScore >= 7500)
        {
            scoreText.color = Colors.instance.red;
        }
        else if (totalScore >= 3000)
        {
            scoreText.color = Colors.instance.purple;
        }
        else if (totalScore >= 1000)
        {
            scoreText.color = Colors.instance.blue;
        }
        else if (totalScore >= 500)
        {
            scoreText.color = Colors.instance.green;
        }
        else
        {
            scoreText.color = Colors.instance.white;
        }
    }
}
