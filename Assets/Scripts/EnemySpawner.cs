using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 5f;

    public float minX = -25f;
    public float maxX = 65f;
    public float minZ = -50f;
    public float maxZ = 50f;
    public float spawnY = 7f;

    private float _spawnTimer;

    void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= spawnInterval)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(minX, maxX),
                spawnY,
                Random.Range(minZ, maxZ)
            );

            Quaternion spawnRotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;
            Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            _spawnTimer = 0f;
        }
    }
}
