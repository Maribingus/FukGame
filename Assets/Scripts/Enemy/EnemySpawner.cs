using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform target;
    public float cooldownTime;
    [SerializeField] private GameObject EnemyPrefab;
    public Vector3 offset;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(cooldownTime); // Wait for the cooldown period to elapse
        StartCoroutine(Spawner());
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefab, target.position + offset, Quaternion.identity);
        print("allahu");
    }
}
