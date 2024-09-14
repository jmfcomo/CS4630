using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewHighScore : MonoBehaviour
{

    public TMP_Text text;
    public HighScore hs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject highGO = GameObject.Find("HighScore");
        hs = highGO.GetComponent<HighScore>();
        text.text = hs.GetHighScoreChanged() ? "You set a new high score!" : "You did not set a new high score";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
