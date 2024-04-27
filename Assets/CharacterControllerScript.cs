using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(moveHorizontal, 0) * speed);

        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(0, moveVertical) * speed);
    }
}