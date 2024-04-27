using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockType blockType = BlockType.Stone;
    public int strength = 1;

    public void SetSprite(Sprite newSprite){
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    
  
}
