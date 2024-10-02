using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    Vector3 launchPos = new Vector3(0, 0, 0);
    public GameObject projectile;
    Rigidbody projectileRigidbody;

    bool fly = false;


    // Start is called before the first frame update
    void Start()
    {
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
            // Get the current mouse position in 2D screen coordinates
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            // Find the delta from the launchPos to the mousePos3D
            Vector3 mouseDelta = mousePos3D - launchPos;

        if (!fly) {
            // Limit mouseDelta to the radius of the Slingshot SphereCollider          
            float maxMagnitude = projectile.GetComponent<SphereCollider>().radius;
            if (mouseDelta.magnitude > maxMagnitude)
            {
                mouseDelta.Normalize();
                mouseDelta *= maxMagnitude;
            }

            // Move the projectile to this new position
            Vector3 projPos = launchPos + mouseDelta;
            projectile.transform.position = projPos;
        }

        if (Input.GetKeyDown("space"))
        {
            fly = true;

            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = - mouseDelta * 15;

        }

    }
}
