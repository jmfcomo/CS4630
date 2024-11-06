using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    GameObject tip;
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        tip = transform.Find("Tip").gameObject;
        line = tip.GetComponent<LineRenderer>();
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += x * 30 * Time.deltaTime;
        pos.y += y * 30 * Time.deltaTime;

        transform.position = pos;

        if (Input.GetButton("Fire1"))
        {
            line.enabled = true;

            Ray ray = new Ray(tip.transform.position, new Vector3(0, 1, 0));
            RaycastHit hit;
            line.SetPosition(0, ray.origin);
            if (Physics.Raycast(ray, out hit, 10))
            {
                line.SetPosition(1, hit.point);
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(10));
            }

        }
        else
        {
            line.enabled = false;
        }
    }
}
