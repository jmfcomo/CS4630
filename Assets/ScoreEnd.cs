using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreEnd : MonoBehaviour
{
    public TMP_Text scoreText;
    public ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        scoreText.text = "You scored " + scoreCounter.getScore() +  "!";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "You scored " + scoreCounter.getScore() + "!";
    }
}
