using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShotBehaviour : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Enemy")
        {

        }
    }
}
