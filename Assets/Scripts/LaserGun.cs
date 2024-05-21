using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject laserPrefab;  // Prefab for the laser
    public Transform gunL;          // Left gun position
    public Transform gunR;          // Right gun position
    public float rayLength = 100f;  // Length of the raycast

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireLaser(gunL);
            FireLaser(gunR);
        }
    }

    void FireLaser(Transform gun)
    {
        // Instantiate laser visual effect
        Instantiate(laserPrefab, gun.position, gun.rotation);

        // Create and visualize the ray
        Ray ray = new Ray(gun.position, gun.forward);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.transform.gameObject.name.Contains("Asteroid"))
            {
                Asteroid asteroid = hit.transform.GetComponent<Asteroid>();
                if (asteroid != null)
                {
                    asteroid.Explode();
                }
            }
        }
    }
}
