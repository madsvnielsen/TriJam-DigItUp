using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterControllerScript : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;

    public Transform drill;
    public SpriteRenderer drillSprite;
    public AudioClip drillSound;

    public float pushbackForce = 1f;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(moveHorizontal, 0) * speed);

        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(0, moveVertical) * speed);

        // flip the character
        if (moveHorizontal < 0)
        {
            //transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (moveHorizontal > 0)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            GetComponent<SpriteRenderer>().flipX = true;

        }

        if (Input.GetKey(KeyCode.W))
        {
            SetDrillPosition(-90f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            SetDrillPosition(0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            SetDrillPosition(90f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            SetDrillPosition(180f);
        }


    }

    private void SetDrillPosition(float newZRotation)
    {
        drill.transform.eulerAngles = new Vector3(0, 0, newZRotation);
    }

    public void MineBlock(Block block)
    {
        block.Break();
        drillSprite.flipX = !drillSprite.flipX;
        // play drill sound
        AudioSource.PlayClipAtPoint(drillSound, transform.position, 0.1f);

        AddPushbackForce(block);
    }

    private void AddPushbackForce(Block block)
    {
        Vector2 blockPosition = block.transform.position;
        Vector2 forceVector = (Vector2)transform.position - (Vector2)blockPosition;
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.AddForce(forceVector * pushbackForce);
    }
}