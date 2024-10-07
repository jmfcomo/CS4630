using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public AudioClip goldSound;

    private void OnTriggerEnter(Collider other)
    {
        RollBall.S.PlaySound(goldSound);
        RollBall.S.score++;
        Destroy(gameObject);
    }
}
