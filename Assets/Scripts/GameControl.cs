using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject cubePrefab;

    public int dropWait = 50; // frames to wait before dropping next block
    private int framesSinceDrop = 0; // counting until next drop

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        framesSinceDrop++;
        print(framesSinceDrop);
        if (framesSinceDrop > dropWait)
        {
            print("drop!");
            DropCube();
        }
    }

    private void DropCube()
    {
        GameObject cube = Instantiate<GameObject>(cubePrefab);
        float xPos = Random.Range(-8.0f, 6.0f);
        Vector3 pos = new Vector3(xPos, 10, -1);
        cube.transform.position = pos;
        framesSinceDrop = 0;
    }
}
