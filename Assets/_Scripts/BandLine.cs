using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandLine : MonoBehaviour
{
    public Transform LeftPoint;
    public Transform RightPoint;
    public Transform CenterPoint;

    LineRenderer slingshotString;

    private void Start()
    {
        slingshotString = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        slingshotString.SetPositions(new Vector3[3]
        {
            LeftPoint.position, CenterPoint.position, RightPoint.position
        });
    }
}
