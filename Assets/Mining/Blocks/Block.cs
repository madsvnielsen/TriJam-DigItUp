using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public ResourceType blockType = ResourceType.Stone;
    public int strength = 1;

    public GameObject brokenOverlay;

    public void SetSprite(Sprite newSprite){
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void Break(){
        if(--strength <= 0){
            Destroy(gameObject);
            return;
        }
        brokenOverlay.SetActive(true);
    }


    
  
}
