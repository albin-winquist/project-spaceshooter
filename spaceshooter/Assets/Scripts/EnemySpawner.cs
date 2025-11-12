using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 1f;
    public float xRange = 8f;
    public float ySpawn = 6f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(-xRange, xRange), ySpawn, 0f);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
