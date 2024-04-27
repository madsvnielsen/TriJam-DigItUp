using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementNormal : MonoBehaviour
{
    float speed = 0.5f;
    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
