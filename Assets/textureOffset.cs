using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textureOffset : MonoBehaviour
{
    public float speed = 0.1f;

    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time) * speed % 1, 0f);
    }
}
