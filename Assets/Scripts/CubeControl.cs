using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeControl : MonoBehaviour
{
    public float dropSpeed = 0.01f;
    public int maxNumber;

    public TextMeshPro label;

    private int value;
    private int startingValue;
    private int[]
        maxNumberByLevel = new int[] { 6, 9, 12, 20 };

    // Start is called before the first frame update
    void Start()
    {
        maxNumber = maxNumberByLevel[GameControl.GET_LEVEL() - 1];
        value = Random.Range(1, maxNumber + 1);
        startingValue = value;
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
            GameControl.CRATE_LOST();
        }
    }

    public void CubeHit(int value)
    {
        this.value -= value;
        if (this.value == 0)
        {
            Destroy(gameObject);
            GameControl.CHANGE_SCORE(startingValue);
        }

        if (this.value < 0)
        {
            Destroy(gameObject);
            GameControl.CHANGE_SCORE(-startingValue);
        }
    }
}
