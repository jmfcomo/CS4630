using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DigitalClock : MonoBehaviour
{
    Text textClock;

    // Start is called before the first frame update
    void Start()
    {
        textClock = GetComponent<Text>();
        textClock.text = "Clock";
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        textClock.text = time.ToString("hh:mm:ss");
    }
}
