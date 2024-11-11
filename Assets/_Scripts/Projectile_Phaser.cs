using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Projectile_Phaser : ProjectileHero
{
    [Header("Projectile_Phaser Inscribed Fields")]
    public float waveFrequency = 100;
    public float waveWidth = 1;
    public float waveRotY = 20;

    private float x0;
    private float birthTime;

    void Start()
    {
        x0 = this.transform.position.x;
        birthTime = Time.time;
    }

    public override void Move()
    {
        Vector3 tempPos = this.transform.position;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        this.transform.position = tempPos;
        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);

        this.transform.position += new Vector3(0, .2f, 0);
        base.Move();
    }
}
