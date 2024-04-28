using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject Swarm;
    public GameObject Speedy;
    public GameObject Boss;

    private int wave = 0;
    private float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    async Task SpawnEnemy()
    {
        int enemiesToSpawn = Mathf.FloorToInt(Mathf.Pow(wave, 2f) / 11.4f + 1.1f * wave);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            await Task.Delay(200);
            Vector3 position = gameObject.transform.position;
            Vector3 randomVector = new Vector3(20, 20, 0);

            float randomAngle = Random.Range(0, 360);
            randomVector = Quaternion.Euler(0, 0, randomAngle) * randomVector;

            if ((i + 1) % 12 == 0 && i != 0)
            {
                Instantiate(Boss, position + randomVector, Quaternion.identity);
            }
            else if ((i + 1) % 4 == 0 && i != 0)
            {
                Instantiate(Speedy, position + randomVector, Quaternion.identity);
            }
            else
            {
                Instantiate(Swarm, position + randomVector, Quaternion.identity);
            }
        }
        wave += 1;
    }
}
