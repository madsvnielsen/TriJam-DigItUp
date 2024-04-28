using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPScript : MonoBehaviour
{
    public float Health;
    public void TakeDamage(float dmg)
    {
        Health -= dmg;
        if(Health < 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
