using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    public AppleTree at;
    public TMP_Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject treeGO = GameObject.Find("AppleTree");
        at = treeGO.GetComponent<AppleTree>();
        levelText.text = "Level: " + at.GetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + at.GetLevel();
    }
}
