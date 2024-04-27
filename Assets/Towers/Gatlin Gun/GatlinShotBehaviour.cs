using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlinShotBehaviour : MonoBehaviour
{
    public int damage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHPScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
