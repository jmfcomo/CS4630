using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    private float x0;
    private float birthTime;


    private void Start()
    {
        x0 = pos.x;
        birthTime = Time.time;
    }
    public override void Move()
    {
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / 2;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + 4 * sin;
        pos = tempPos;

        base.Move();
    }
}
