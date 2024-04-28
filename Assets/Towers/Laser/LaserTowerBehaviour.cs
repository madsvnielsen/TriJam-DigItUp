using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerBehaviour : MonoBehaviour
{

    Collider2D towerCollider;
    List<GameObject> enemiesSpotted = new List<GameObject>();
    private Transform target;
    private Transform lastTarget;
    public float dps = 0.1f;
    public GameObject laser;

    void Start()
    {
        InvokeRepeating("Shoot", 1f, 0.1f);
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
            if (lastTarget != target)
            {
                lastTarget = target;
                dps = 1;
            }
            if (target != null)
            {
                laser.SetActive(true);
                laser.transform.localScale = new Vector3(Vector3.Distance(transform.position, target.position), laser.transform.localScale.y, laser.transform.localScale.z);
                if (target.gameObject.tag == "Enemy")
                {
                    target.gameObject.GetComponent<EnemyHPScript>().TakeDamage(dps * 0.1f);
                }

                if (dps > 20)
                {
                    return;
                }
                dps *= 1.05f;
                laser.transform.localScale = new Vector3(laser.transform.localScale.x, 1 + (dps - 0.1f) / 4, laser.transform.localScale.z);
            }
            else
            {
                laser.SetActive(false);
            }
        }
        else
        {
            laser.SetActive(false);
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
