using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerPrefab;
    public BulletSpawner bulletSpawner;
    private GameObject currentTower;
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
            fixedX = 1f;
            if (currentTower != null && isMoving)
            {
                Destroy(currentTower);
            }
            currentTower = Instantiate(towerPrefab);
            isMoving = true;
        }
        // Press Q to place the tower on the left side
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            fixedX = -1f;
            if (currentTower != null && isMoving)
            {
                Destroy(currentTower);
            }
            currentTower = Instantiate(towerPrefab);
            isMoving = true;
        }

        // Press left mouse button to place the tower
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = false;
            bulletSpawner.ShootBullet(currentTower.transform.position, -fixedX);
        }

        if (currentTower != null && isMoving)
        {
            MoveTowerWithMouse(currentTower, fixedX);
        }
    }

    void MoveTowerWithMouse(GameObject tower, float fixedX)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Distance from the camera
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.x = fixedX; // Set the x-axis to the fixed value
        tower.transform.position = worldPosition;
    }
}
