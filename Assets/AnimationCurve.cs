using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurve : MonoBehaviour
{
    public GameObject c0;
    public GameObject c1;
    Vector3 p0, p1, p01;

    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        p0 = c0.transform.position;
        p1 = c1.transform.position;
        transform.position = p0;
        p01 = p1 - p0;
    }

    // Update is called once per frame
    void Update()
    {
//        transform.transform.position = p0 + p01 * curve.Evaluate(Time.time);
    }
}
