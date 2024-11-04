using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject spaceship;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        spaceship.GetComponent<Hero>().weaponFire += FireProjectile;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireProjectile()
    {
        GameObject pGo = Instantiate<GameObject>(projectilePrefab);
        pGo.transform.position = this.transform.position;
        Rigidbody rb = pGo.GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * 5;
    }
}
