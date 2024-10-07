using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTest : MonoBehaviour
{
    AudioSource adSource;

    private void Start()
    {
        adSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        adSource.Play();
    }
}
