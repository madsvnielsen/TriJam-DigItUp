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
        Instantiate(Enemy, new Vector3(Random.Range(-10f,10f),310,0),Quaternion.identity);
    }

    
}
