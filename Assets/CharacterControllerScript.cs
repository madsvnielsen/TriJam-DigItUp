using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;

    public Transform drill;

    public float pushbackForce = 1f;

    

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

        if(Input.GetKey(KeyCode.W)){
            SetDrillPosition(-90f);
        }
        if(Input.GetKey(KeyCode.A)){
            SetDrillPosition(0f);
        }
        if(Input.GetKey(KeyCode.S)){
            SetDrillPosition(90f);
        }
        if(Input.GetKey(KeyCode.D)){
            SetDrillPosition(180f);
        }


    }

    private void SetDrillPosition(float newZRotation){
        drill.transform.eulerAngles = new Vector3(0,0,newZRotation);
    }

    public void MineBlock(Block block){
        block.Break();
        //Add materials here somehow
        AddPushbackForce(block);
    }

    private void AddPushbackForce(Block block){
        Vector2 blockPosition = block.transform.position;
        Vector2 forceVector = (Vector2)transform.position - (Vector2)blockPosition;
        rb.AddForce(forceVector * pushbackForce);
    }
}