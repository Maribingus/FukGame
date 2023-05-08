using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public float bulletForce;
    public float damage;


    public void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        //bullet.GetComponent<ProjectileStats>().damage = damage;

    }
}