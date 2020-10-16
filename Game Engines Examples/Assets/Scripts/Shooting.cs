using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float fireRate = 3;

    void OnEnable()
    {
        StartCoroutine(ShootingCoroutine());
    }

    void Shoot()
    {
        GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
        bullet.transform.position = spawnPoint.position;
        bullet.transform.rotation = this.transform.rotation;
    }

    System.Collections.IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                yield return new WaitForSeconds(1.0f / fireRate);
            }
            yield return null;
        }
    }
}
