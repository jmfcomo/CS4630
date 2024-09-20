using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S;

    [Header("Inscribed")]
    public Text uitLevel;
    public Text uitShots;
    public Text uitScore;
    public Vector3 castlePos;
    public GameObject[] castles;

    [Header("Dynamic")]
    public int level;
    public int levelMax;
    public int shotsTaken;
    public int shotsRemaining;
    public int score;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        level = 0;
        shotsTaken = 0;
        levelMax = castles.Length;
        score = 0;
        shotsRemaining = 3;
        StartLevel();
    }

    void StartLevel()
    {
        if (castle != null)
        {
            Destroy(castle);
        }

        Projectile.DESTROY_PROJECTILES();

        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;

        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;

        shotsRemaining = 3;

        FollowCam.SWITCH_VIEW(FollowCam.eView.both);
    }

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Remaining: " + shotsRemaining;
        uitScore.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();

        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            FollowCam.SWITCH_VIEW(FollowCam.eView.both);
            Invoke("NextLevelWin", 2f);
        }
    }

    void NextLevelWin()
    {
        NextLevel(true);
    }

    void NextLevel(bool isWin)
    {
        if (isWin) {
            switch (shotsRemaining)
            {
                case 2:
                    score += 1000;
                    break;
                case 1:
                    score += 500;
                    break;
                case 0:
                    score += 100;
                    break;
            }
        }

        level++;
        if (level == levelMax)
        {
            level = 0;
            shotsTaken = 0;
        }
        StartLevel();
    }

    static public void SHOT_FIRED()
    {
        S.shotsTaken++;
        S.shotsRemaining--;
    }

    static public GameObject GET_CASTLE()
    {
        return S.castle;
    }

    static public void BALL_SLEEP()
    {
        if (S.shotsRemaining == 0)
        {
            S.NextLevel(false);
        }
    }

}
