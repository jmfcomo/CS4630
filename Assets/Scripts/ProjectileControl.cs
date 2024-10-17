using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileControl : MonoBehaviour
{
    private Vector3 direction;
    public TextMeshPro label;

    public float projectileSpeed = 1.0f;
    private int value;

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public void SetLabel(int value)
    {
        label.text = value.ToString();
        this.value = value;
    }

    private void FixedUpdate()
    {
        Vector3 move = direction.normalized * projectileSpeed;
        transform.Translate(move);

        if (transform.position.y > 10 || transform.position.x < -9 || transform.position.x > 6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject collided = other.gameObject;
        CubeControl collidedScript = collided.GetComponent<CubeControl>();
        if (collidedScript != null)
        {
            collidedScript.CubeHit(value);
        }
        Destroy(gameObject);
    }
}
