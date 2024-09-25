using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, startposy;
    public GameObject cam;
    public float parallaxEffect;
    public float parallaxEffecty;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        startposy = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * parallaxEffecty);
        transform.position = new Vector3(startpos + dist, startposy + disty, transform.position.z);
    }
}
