using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        int highScore = PlayerPrefs.GetInt("HighScore");

        scoreText.text = "Your Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

}
