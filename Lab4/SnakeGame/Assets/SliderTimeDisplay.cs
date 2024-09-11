using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimeDisplay : MonoBehaviour
{
    Slider sliderUI;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        sliderUI = GetComponent<Slider>();
        sliderUI.minValue = 0;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timeProp = (Time.time - startTime) / 30f;
        sliderUI.value = timeProp;
    }
}
