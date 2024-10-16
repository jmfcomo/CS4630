using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject cubePrefab;

    public int dropWait = 500; // frames to wait before dropping next block
    private int framesSinceDrop = 0; // counting until next drop

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        framesSinceDrop++;
        if (framesSinceDrop > dropWait)
        {
            DropCube();
        }
    }

    private void DropCube()
    {
        GameObject cube = Instantiate<GameObject>(cubePrefab);
    }
}
