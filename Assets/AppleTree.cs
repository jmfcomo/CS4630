using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]                                                  // a
    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject goldApplePrefab;
    public GameObject poisonApplePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    public float goldenAppleChance = 0.05f;
    // real chance is lower because this runs after gold apples get picked
    public float poisonAppleChance = 0.05f;

    public int level = 1;
    private int levelFrames = 0;

    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple;
        if (Random.value < goldenAppleChance)
        {
            apple = Instantiate<GameObject>(goldApplePrefab);
        }
        else if (Random.value < poisonAppleChance)
        {
            apple = Instantiate<GameObject>(poisonApplePrefab);
        }
        else
        {
            apple = Instantiate<GameObject>(applePrefab);
        }
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
    void Update()
    {
        // Leveling
        levelFrames++;
        if (levelFrames == 1000)
        {
            levelFrames = 0;
            level++;
            speed *= 1.1f;
            appleDropDelay *= 0.9f;
            changeDirChance *= 1.1f;
            poisonAppleChance *= 1.1f;
            goldenAppleChance *= 1.1f;
        }

        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

    public int GetLevel()
        { return level; }
}