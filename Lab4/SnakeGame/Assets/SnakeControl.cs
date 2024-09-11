using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SnakeControl : MonoBehaviour
{
    float moveSpeed = 5.0f;
    float steerSpeed = 180f;
    int score = 0;
    GameObject backSegment;
    GameObject head;

    public TMP_Text scoreText;
    public GameObject applePrefab;
    public GameObject bodyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        SpawnApple();
        scoreText.text = "Score: " + score;
        backSegment = null;
    }

    // Update is called once per frame
    void Update()
    {
        // move forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        // steering
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }
        SpawnApple();
        GrowBody();
    }

    void SpawnApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = new Vector3(Random.value * 40 - 20, 0, Random.value * 40 - 20);
    }

    void GrowBody()
    {
        GameObject body = Instantiate(bodyPrefab);
        body.transform.parent = backSegment ? backSegment.transform : transform;
        body.transform.position = body.transform.parent.position;
        body.transform.rotation = body.transform.parent.rotation;
        body.transform.position -= transform.forward * 1.2f;
        backSegment = body;
    }
}
