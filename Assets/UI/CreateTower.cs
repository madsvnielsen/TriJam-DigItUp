using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateTower : MonoBehaviour
{

    public GameObject towerPrefab;

    public Camera planetCamera;

    public GameObject planet;

    private GameObject spawnedTower;
    private int i = 0;
    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;

    private float correctionX = 25.82238f;
    private float correctionY = 302.955f;
    private bool isTowerSelected = false;

    private void Start()
    {
        correctionX = planet.transform.position.x - correctionX;
        correctionY = planet.transform.position.y - correctionY;
    }

    private void Update()
    {
        if (isTowerSelected)
        {
            Vector3 worldPosition = planetCamera.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            worldPosition.x += correctionX;
            worldPosition.y += correctionY;

            // Project it to the surface of the planet
            Vector3 planetCenter = planet.transform.position;
            Vector3 direction = worldPosition - planetCenter;

            direction.Normalize();
            worldPosition = planetCenter + direction * 5.3f;

            spawnedTower.transform.position = worldPosition;
            spawnedTower.transform.right = direction;

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(spawnedTower);
                isTowerSelected = false;
                spawnedTower = null;
            }
            if (Input.GetMouseButtonDown(0))
            {
                isTowerSelected = false;
                spawnedTower = null;
                if (i == 1)
                {
                    InventoryManager.removeItemFromInventory(ResourceType.Copperium, 5);
                    InventoryManager.removeItemFromInventory(ResourceType.Golduim, 2);
                    InventoryManager.removeItemFromInventory(ResourceType.Spacesonium, 0);
                }
                else if (i == 2)
                {
                    InventoryManager.removeItemFromInventory(ResourceType.Copperium, 2);
                    InventoryManager.removeItemFromInventory(ResourceType.Golduim, 6);
                    InventoryManager.removeItemFromInventory(ResourceType.Spacesonium, 1);
                }
                else if (i == 3)
                {
                    InventoryManager.removeItemFromInventory(ResourceType.Copperium, 1);
                    InventoryManager.removeItemFromInventory(ResourceType.Golduim, 3);
                    InventoryManager.removeItemFromInventory(ResourceType.Spacesonium, 7);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetTowerPrefab(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetTowerPrefab(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetTowerPrefab(3);
        }
    }



    public void SetTowerPrefab(int i)
    {
        if (i == 1)
        {
            if (InventoryManager.Copperium < 5 || InventoryManager.Goldium < 2)
            {
                return;
            }
            towerPrefab = tower1;
        }
        else if (i == 2)
        {
            if (InventoryManager.Copperium < 2 || InventoryManager.Goldium < 6 || InventoryManager.Spacesonium < 1)
            {
                return;
            }
            towerPrefab = tower2;
        }
        else if (i == 3)
        {
            if (InventoryManager.Copperium < 1 || InventoryManager.Goldium < 3 || InventoryManager.Spacesonium < 7)
            {
                return;
            }
            towerPrefab = tower3;
        }
        isTowerSelected = true;
        this.i = i;

        Vector3 worldPosition = planetCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        worldPosition.x += correctionX;
        worldPosition.y += correctionY;

        // Project it to the surface of the planet
        Vector3 planetCenter = planet.transform.position;
        Vector3 direction = worldPosition - planetCenter;

        direction.Normalize();
        worldPosition = planetCenter + direction * 5.3f;

        spawnedTower = Instantiate(towerPrefab, worldPosition, Quaternion.identity);
        spawnedTower.transform.right = direction;

        spawnedTower.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
