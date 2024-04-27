using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject Enemy;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 10f, 10f);

    }

    void SpawnEnemy()
    {
        Vector3 position = gameObject.transform.position;
        // add a random vector to the position
        Vector3 randomVector = new Vector3(20, 20, 0);

        // rotate the vector by a random angle
        float randomAngle = Random.Range(0, 360);
        randomVector = Quaternion.Euler(0, 0, randomAngle) * randomVector;

        GameObject newEnemy = Instantiate(Enemy, position + randomVector, Quaternion.identity);
    }


}
