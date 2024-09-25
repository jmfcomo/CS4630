using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    Vector3 initialOffset;
    Vector3 cameraDesPosition;

    // Start is called before the first frame update
    void Start()
    {
        // calculate offset
        initialOffset = transform.position - targetObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraDesPosition = targetObject.position + initialOffset;

        transform.position = Vector3.Lerp(transform.position, cameraDesPosition, Time.deltaTime);

        Debug.DrawLine(transform.position, cameraDesPosition, Color.green);
    }
}
