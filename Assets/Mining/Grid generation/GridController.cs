using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour{

    public int width, height;

    public Block blockPrefab;

    private List<Block> blocks;

  
    float goldThreshold = 0.2f;
    float spaceThreshold = 0.2f;
    float copperiumThreshold = 0.2f;

    public Sprite goldSprite;
    public Sprite spaceSprite;
    public Sprite copperiumSprite;

    public void Start(){
        GenerateGrid();
    }

    void GenerateGrid(){

        float xNoiseOffset = Random.Range(0,100) * 100000f;
        float yNoiseOffset = Random.Range(0,100) * 100000f;

        float goldOffset = width;
        float spaceOffset = width * 2;
        float copperiumOffset = width * 3;

        blocks = new List<Block>();

        
        for(int x = -(width/2); x < width/2; x++){
            for(int y = 0; y > -height; y--){
                Block newBlock = Instantiate(blockPrefab, new Vector3(x + transform.position.x, y + transform.position.y, 0), Quaternion.identity);
                newBlock.name = $"Block {x}{y}";
                Quaternion currentRotation = transform.rotation;
                int randomZRotation = Random.Range(0, 4); // 0, 1, 2, or 3
                float zAngle = randomZRotation * 90f;
                newBlock.transform.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, zAngle);

                
                if (Mathf.PerlinNoise((x + goldOffset + xNoiseOffset) / 10f - 0.1f, (y + goldOffset + yNoiseOffset) / 10f - 0.1f) > 1 - goldThreshold)
                {
                    //Set goldium
                    newBlock.strength = 2;
                    newBlock.blockType = ResourceType.Golduim;
                    newBlock.SetSprite(goldSprite);
                }
                else if (Mathf.PerlinNoise((x + spaceOffset + xNoiseOffset) / 10f - 0.1f, (y + spaceOffset + yNoiseOffset) / 10f - 0.1f) > 1 - spaceThreshold)
                {
                    //Set spaceononium
                    newBlock.strength = 2;
                    newBlock.blockType = ResourceType.Spacesonium;
                    newBlock.SetSprite(spaceSprite);
                }
                else if (Mathf.PerlinNoise((x + copperiumOffset + xNoiseOffset) / 10f - 0.1f, (y + copperiumOffset + yNoiseOffset) / 10f - 0.1f) > 1 - copperiumThreshold)
                {
                    //Set copperium
                    newBlock.strength = 2;
                    newBlock.blockType = ResourceType.Copperium;
                    newBlock.SetSprite(copperiumSprite);
                }
                
                blocks.Add(newBlock);
            }
        }
    }
}
