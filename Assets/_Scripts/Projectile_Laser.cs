using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Laser : ProjectileHero
{
    LineRenderer line;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = true;
    }

    // Update is called once per frame
    public override void Move()
{
    this.transform.position = weapon.transform.position;

    Ray ray = new Ray(transform.position, transform.up);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
        // Calculate the distance to the hit point
        float distanceToHit = Vector3.Distance(transform.position, hit.point);

        // Set the second point of the line renderer to a fixed distance along transform.up
        float maxDistance = 100f; // Adjust this to your desired maximum distance
        float clampedDistance = Mathf.Min(distanceToHit, maxDistance);
        Vector3 endPoint = transform.position + new Vector3(0, 1, 0) * clampedDistance;

        line.SetPosition(0, ray.origin);
        line.SetPosition(1, endPoint);
    }
    else
    {
        float maxDistance = 100f;
        line.SetPosition(0, ray.origin);
        Vector3 endPoint = transform.position + new Vector3(0, 1, 0) * maxDistance;
        line.SetPosition(1, ray.GetPoint(maxDistance));
    }

    base.Move();

    if (Input.GetButtonUp("Jump"))
    {
        Destroy(this.gameObject);
    }
}


}
