using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerBehaviour : MonoBehaviour
{

    Collider2D towerCollider;
    List<GameObject> enemiesSpotted = new List<GameObject>();
    private Transform target;

    void Start()
    {
        
        transform.GetChild(2).GetComponent<LineRenderer>().enabled = false;
        InvokeRepeating("Shoot", 0.1f, 0.1f);
    }

    

    private void Shoot()
    {
        if (enemiesSpotted.Count >= 1)
        {
            float smallestDistance = 100f;
            foreach (GameObject go in enemiesSpotted)
            {
                float newDist = Vector3.Distance(transform.position, go.transform.position);
                if (newDist < smallestDistance)
                {
                    smallestDistance = newDist;
                    target = go.transform;
                }
            }
            if (target != null)
            {
                
                Debug.Log("Shoot");
                transform.GetChild(2).GetComponent<LineRenderer>().enabled = true;
                transform.GetChild(2).GetComponent<LineRenderer>().SetPosition(0, transform.GetChild(1).GetChild(1).position);
                transform.GetChild(2).GetComponent<LineRenderer>().SetPosition(1, target.position);
                if(target.gameObject.tag == "Enemy")
                {
                    target.gameObject.GetComponent<EnemyHPScript>().TakeDamage(2);
                }
            }
        }
    }
    void Update()
    {
        if (target != null)
        {
            transform.GetChild(1).right = target.position - transform.GetChild(1).position;
        }
        else
        {
            transform.GetChild(2).GetComponent<LineRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Spotted");
            enemiesSpotted.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && enemiesSpotted.Contains(collision.gameObject))
        {
            enemiesSpotted.Remove(collision.gameObject);
        }
    }
}
