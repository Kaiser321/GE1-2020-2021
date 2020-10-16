using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public float radius = 10;
    public int max = 5;
    public GameObject enemyPrefab;

    void OnEnable()
    {
        StartCoroutine(SpawnCoroutine());
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(-radius, radius), transform.position.y, Random.Range(-radius, radius));
        GameObject enemy = Instantiate(enemyPrefab, pos, new Quaternion(0, 0, 0, 0));
        enemy.transform.parent = this.transform;
        enemy.tag = "Enemy";
    }

    System.Collections.IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length < max)
            {
                Spawn();
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
