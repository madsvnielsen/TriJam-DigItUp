using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShotBehaviour : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
