using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // drag 10 enemies here
    public float spawnRate = 1f;
    public float xRange = 8f;
    public float ySpawn = 6f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0)
            return;

        Vector3 pos = new Vector3(
            Random.Range(-xRange, xRange),
            ySpawn,
            0f
        );

        GameObject randomEnemy =
            enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Instantiate(randomEnemy, pos, Quaternion.identity);
    }
}
