using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject Enemy1,Enemy2, Enemy3;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 10f, 10f);
        
    }

    
}
