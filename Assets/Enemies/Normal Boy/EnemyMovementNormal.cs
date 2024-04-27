using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementNormal : MonoBehaviour
{
    float speed = 2f;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "planet")
        {
            GameObject.FindGameObjectWithTag("ENDGAME").GetComponent<endsTheGame>().endGame();
        }
    }
}
