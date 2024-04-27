using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject Enemy;
    private int wave = 0;
    private float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        int enemiesToSpawn = Mathf.FloorToInt(Mathf.Pow(wave, 2f) / 11.4f + 1.1f * wave);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 position = gameObject.transform.position;
            Vector3 randomVector = new Vector3(20, 20, 0);

            float randomAngle = Random.Range(0, 360);
            randomVector = Quaternion.Euler(0, 0, randomAngle) * randomVector;

            GameObject newEnemy = Instantiate(Enemy, position + randomVector, Quaternion.identity);
        }
        wave += 1;
    }
}
