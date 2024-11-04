using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject[] weaponAnchors;

    public delegate void WeaponFireDelegate();
    public WeaponFireDelegate weaponFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump")==1)
        {
            //FireProjectile(weaponAnchors[0]);
            weaponFire();
        }
    }

    //void FireProjectile(GameObject anchor)
    //{
    //    GameObject pGO = Instantiate<GameObject>(projectilePrefab);
    //    pGO.transform.position = anchor.transform.position;
    //    Rigidbody rb = pGO.GetComponent<Rigidbody>();
    //    rb.velocity = Vector3.up * 5;
    //}
}
