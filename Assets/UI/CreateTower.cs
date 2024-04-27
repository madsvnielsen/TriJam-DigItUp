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
            }
        }
    }

    public void SetTowerPrefab(int i)
    {
        if (i == 1)
        {
            towerPrefab = tower1;
        }
        else if (i == 2)
        {
            towerPrefab = tower2;
        }
        else if (i == 3)
        {
            towerPrefab = tower3;
        }
        isTowerSelected = true;

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
