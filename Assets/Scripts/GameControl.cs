using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    static private GameControl S;

    public GameObject cubePrefab;
    public GameObject sliderObject;
    public TMP_Text levelText;
    public TMP_Text scoreText;
    public TMP_Text crateText;
    public TMP_Text ballsText;
    public TMP_Text timeText;

    public int dropWait; // frames to wait before dropping next block
    private int framesSinceDrop; // counting until next drop
    public int timeLeft;
    public int framesSecond;
    private int score;
    private int level;
    private int[] cratesByLevel;
    private int[] dropWaitByLevel;
    private int cratesLeft;
    private int cratesHit;
    private int[] ballsRemaining;
    private int[] ballsRemainingByLevel;
    private Slider slider;

    void Start()
    {
        S = this;
        framesSinceDrop = 0;
        framesSecond = 0;
        timeLeft = 300;
        score = 0;
        level = 1;
        cratesByLevel = new int[] { 15, 20, 30, 60 };
        cratesLeft = cratesByLevel[0];
        cratesHit = 0;
        dropWaitByLevel = new int[] { 200, 150, 100, 50 };
        dropWait = dropWaitByLevel[0];
        ballsRemainingByLevel = new int[] { 20, 40, 80, 200 };
        ballsRemaining = new int[] { ballsRemainingByLevel[0], ballsRemainingByLevel[0], ballsRemainingByLevel[0] };
        slider = sliderObject.GetComponent<Slider>();
        slider.value = timeLeft;
    }

    private void FixedUpdate()
    {
        // update timer
        framesSecond++;
        if (framesSecond > 49)
        {
            framesSecond = 0;
            timeLeft--;
        }

        // drop cube
        framesSinceDrop++;
        if (framesSinceDrop > dropWait)
        {
            DropCube();
        }

        // score can't go negative
        if (score < 0)
        {
            score = 0;
        }

        // level update
        if (cratesLeft == 0)
        {
            ChangeLevel();
        }

        // UI update
        levelText.text = "Level: " + level.ToString();
        scoreText.text = "Score: " + score.ToString();
        crateText.text = "Crates Left: " + cratesLeft.ToString();
        ballsText.text = 
            ballsRemaining[0].ToString() + " x 1, " + 
            ballsRemaining[1].ToString() + " x 2, " + 
            ballsRemaining[2].ToString() + " x 3";
        timeText.text = timeLeft.ToString() + " Seconds Left";
        slider.value = timeLeft;

    }

    private void DropCube()
    {
        GameObject cube = Instantiate<GameObject>(cubePrefab);
        float xPos = Random.Range(-8.0f, 6.0f);
        Vector3 pos = new Vector3(xPos, 10, -1);
        cube.transform.position = pos;
        framesSinceDrop = 0;
    }

    private void ChangeLevel()
    {
        // must get at least 80% of crates to pass
        if (((cratesHit * 1.0f) / cratesByLevel[level - 1]) >= 0.8f)
        {
            level++;
        }
        else
        {
            level--;
        }

        if (level > 4)
        {
            //TODO: win condition!
        }
        if (level < 1) // can't go below level 1
        {
            level = 1;
        }

        if (level <= 4)
        {
            cratesHit = 0;
            cratesLeft = cratesByLevel[level - 1];
            dropWait = dropWaitByLevel[level - 1];
            ballsRemaining[0] = ballsRemainingByLevel[level - 1];
            ballsRemaining[1] = ballsRemainingByLevel[level - 1];
            ballsRemaining[2] = ballsRemainingByLevel[level - 1];
        }
    }

    static public void CHANGE_SCORE(int change)
    {
        S.score += change * S.level;
        S.cratesLeft--;
        if (change > 0)
        {
            S.cratesHit++;
        }
    }

    static public void CRATE_LOST()
    {
        S.cratesLeft--;
    }

    static public int GET_LEVEL()
    { return S.level; }

    static public bool SHOOT_PROJECTILE(int value)
    {
        if (S.ballsRemaining[value - 1] > 0)
        {
            S.ballsRemaining[value - 1]--;
            return true;
        }
        return false;
    }
}
