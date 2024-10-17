using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject launchOrigin;

    public void LaunchProjectile(int value)
    {
        GameObject projectile = Instantiate<GameObject>(projectilePrefab);
        projectile.transform.position = launchOrigin.transform.position;
        ProjectileControl projControl = projectile.GetComponent<ProjectileControl>();
        projControl.SetDirection(launchOrigin.transform.up);
        projControl.SetLabel(value);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (GameControl.SHOOT_PROJECTILE(1))
            {
                LaunchProjectile(1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (GameControl.SHOOT_PROJECTILE(2))
            {
                LaunchProjectile(2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (GameControl.SHOOT_PROJECTILE(3))
            {
                LaunchProjectile(3);
            }
        }
    }
}
