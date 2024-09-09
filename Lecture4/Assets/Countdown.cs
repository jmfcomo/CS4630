using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    Text countdown;
    public float count;
    float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        countdown = GetComponent<Text>();
        totalTime = 30;
        count = totalTime;

        Color c = countdown.color;
        c.a = 1;
        countdown.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        if (count > 0)
        {
            countdown.text = count.ToString("F1") + " Seconds Remaining";
            Color c = countdown.color;
            c.a = 1 * (count / totalTime);
            countdown.color = c;
        }
        else 
        {
            countdown.text = "Time is up";
            Color c = countdown.color;
            c.a = 1;
            countdown.color = c;
        }



    }
}
