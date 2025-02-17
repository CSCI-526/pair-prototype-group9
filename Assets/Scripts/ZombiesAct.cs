using UnityEngine;
using System.Collections;

public class ZombiesAct : MonoBehaviour
{
    public GameObject zombiePrefab;
    private float StartLine = 10;
    private float minY = -5;
    private float maxY = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(InstantiateNewZombieStrategy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstantiateNewZombieStrategy()
    {
        while (true)
        {
            float waitTime = Random.Range(0, 5); // Random wait time between 0 to 5 seconds
            yield return new WaitForSeconds(waitTime);
            InstantiateNewZombie();
        }
    }

    void InstantiateNewZombie()
    {
        Vector2 spawnPosition = InstantiateLocationStrategy();
        GameObject newZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
        newZombie.AddComponent<ZombieMovement>();
    }

    Vector2 InstantiateLocationStrategy()
    {
        float x = Random.Range(minY, maxY);
        return new Vector2(x, StartLine);
    }
}
