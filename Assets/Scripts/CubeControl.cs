using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeControl : MonoBehaviour
{
    public float dropSpeed = 0.01f;
    public int maxNumber = 6;

    public TextMeshPro label;

    private int value;

    // Start is called before the first frame update
    void Start()
    {
        value = Random.Range(1, maxNumber + 1);  
    }

    private void FixedUpdate()
    {
        label.text = value.ToString();

        Vector3 pos = transform.position;
        pos.y = pos.y - dropSpeed;
        transform.position = pos;

        if (pos.y < 0.5)
        {   
            Destroy(gameObject);
        }
    }

    public void CubeHit(int value)
    {
        this.value -= value;
        if (this.value == 0)
        {
            Destroy(gameObject);
            // get some points
        }

        if (this.value < 0)
        {
            Destroy(gameObject);
            // but something's wrong
        }
    }
}
