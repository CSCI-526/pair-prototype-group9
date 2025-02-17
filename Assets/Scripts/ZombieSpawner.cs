using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), 10f); // 生成在上方
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
