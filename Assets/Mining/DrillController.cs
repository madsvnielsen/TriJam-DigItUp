using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Block")
        {
            GetComponentInParent<CharacterControllerScript>().MineBlock(col.GetComponent<Block>());
        }
    }
}
