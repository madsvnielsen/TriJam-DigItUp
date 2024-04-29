using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public ResourceType blockType = ResourceType.Stone;
    [SerializeField] public int strength = 2;
    private int currentStrength;

    public GameObject brokenOverlay;

    public void Start()
    {
        currentStrength = strength;
    }

    public void SetSprite(Sprite newSprite)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void Break()
    {
        if (--currentStrength <= 0)
        {

            //Add materials here somehow
            if (blockType != ResourceType.Stone)
            {
                InventoryManager.addItemToInventory(blockType, 1);
            }
            Destroy(gameObject);
            return;
        }
        if (currentStrength == strength / 2)
        {
            brokenOverlay.SetActive(true);
        }
    }




}
