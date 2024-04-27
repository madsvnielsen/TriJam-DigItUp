using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] float range = 5f;
    [SerializeField] int damage = 5;
    void Start()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject.tag == "Enemy")
            {
                collider.gameObject.GetComponent<EnemyHPScript>().TakeDamage(damage);
            }
        }
        Destroy(gameObject,1f);
    }

    
}
