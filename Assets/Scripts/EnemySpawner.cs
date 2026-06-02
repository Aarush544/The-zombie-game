using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 5f;

    private float _spawnTimer;

    void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= spawnInterval)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            _spawnTimer = 0f;
        }
    }
}
