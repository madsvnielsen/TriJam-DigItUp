using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlinGunScript : MonoBehaviour
{
    Collider2D towerCollider;
    List<GameObject> enemiesSpotted = new List<GameObject>();
    private Transform target;
    [SerializeField] private GameObject shot;
    void Start()
    {
        towerCollider = GetComponent<Collider2D>();
        InvokeRepeating("Shoot", 1f, 1f);
    }
    private void Shoot()
    {
        if(enemiesSpotted.Count >= 1)
        {
            float smallestDistance = 100f;
            foreach(GameObject go in enemiesSpotted)
            {
                float newDist = Vector3.Distance(transform.position, go.transform.position);
                if(newDist < smallestDistance)
                {
                    smallestDistance = newDist;
                    target = go.transform;
                }
            }
            if(target != null)
            {

                Debug.Log("Shoot");
                GameObject _shot = Instantiate(shot, transform.GetChild(1).GetChild(1).position, Quaternion.identity);
                _shot.GetComponent<Rigidbody2D>().AddForce(transform.GetChild(1).right*100f);
            }
        }
    }

    void Update()
    {
        if(target != null)
        {
            transform.GetChild(1).right = target.position - transform.GetChild(1).position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
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
