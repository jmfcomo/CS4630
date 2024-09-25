using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    private Text _textUITime;
    private float _startTime;

    void Awake()
    {
        _textUITime = GetComponent<Text>();
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedSeconds = (Time.time - _startTime);
        string timeMessage = "Elapsed time = " + elapsedSeconds.ToString("F");
        _textUITime.text = timeMessage;
    }
}
