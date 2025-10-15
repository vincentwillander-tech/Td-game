using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;    // The enemy to spawn
    [SerializeField] private float spawnInterval = 3f;  // Time between spawns
    [SerializeField] private int maxEnemies = 10;       // Max enemies at one time

    private float timer = 0f;
    private int currentEnemyCount = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Spawn enemy at this spawner's position, no rotation
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        currentEnemyCount++;
    }
}