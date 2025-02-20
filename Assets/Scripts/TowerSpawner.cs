using UnityEngine;
using System.Collections.Generic;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerPrefab;
    public BulletSpawner bulletSpawnerPrefab;
    private List<GameObject> towers = new List<GameObject>();
    private GameObject currentTower; // Declare currentTower as a class member
    private float fixedX = 1f;
    private bool isMoving = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialization if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Press E to place the tower on the right side
        if (Input.GetKeyDown(KeyCode.E))
        {
            fixedX = 7f;
            if (isMoving)
            {
                DestroyCurrentTower();
            }
            CreateNewTower();
        }
        // Press Q to place the tower on the left side
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            fixedX = -7f;
            if (isMoving)
            {
                DestroyCurrentTower();
            }
            CreateNewTower();
        }

        // Press left mouse button to place the tower
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = false;
            if (currentTower != null)
            {
                InitializeBulletSpawner(currentTower);
            }
        }

        if (currentTower != null && isMoving)
        {
            MoveTowerWithMouse(currentTower, fixedX);
        }
    }

    private void CreateNewTower()
    {
        currentTower = Instantiate(towerPrefab);
        towers.Add(currentTower);
        isMoving = true;
    }

    private void DestroyCurrentTower()
    {
        if (currentTower != null)
        {
            Destroy(currentTower);
        }
    }

    private void InitializeBulletSpawner(GameObject tower)
    {
        if (bulletSpawnerPrefab != null)
        {
            BulletSpawner bulletSpawner = Instantiate(bulletSpawnerPrefab, tower.transform.position, Quaternion.identity);
            bulletSpawner.Initialize(tower.transform.position);
        }
        else
        {
            Debug.LogError("BulletSpawnerPrefab is not assigned in the Inspector.");
        }
    }

    void MoveTowerWithMouse(GameObject tower, float fixedX)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z; 
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        worldPosition.x = fixedX; // Keep X locked
        worldPosition.z = 0f;     // Ensure Z is zero in 2D

        tower.transform.position = worldPosition;
    }
}
