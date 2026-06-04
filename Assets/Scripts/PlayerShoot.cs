using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate = 0.5f;

    [Header("Initial Setup")]

    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;
    public Vector3 bulletRotationOffset = Vector3.zero;
    public AudioSource bulletAudioSource;

    [Header("Enemy Alert")]
    public string enemyTag = "Enemy";
    public float alertRange = 10f;

    private float _shootTimer;

    private void Update()
    {
        _shootTimer -= Time.deltaTime;

        if (Mouse.current.leftButton.wasPressedThisFrame && _shootTimer <= 0)
        {
            Vector3 shotDirection = bulletSpawnTransform.forward;
            Quaternion spawnRotation = Quaternion.LookRotation(shotDirection) * Quaternion.Euler(bulletRotationOffset);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, spawnRotation);

            bullet.GetComponent<Rigidbody>().AddForce(shotDirection * bulletSpeed, ForceMode.Impulse);

            bulletAudioSource.Play();
            AlertNearbyEnemies();
            
            _shootTimer = 1f / fireRate;
        }
    }

    void AlertNearbyEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemyObject in enemies)
        {
            if (Vector3.Distance(transform.position, enemyObject.transform.position) <= alertRange)
            {
                enemyObject.GetComponent<EnemyAI>().Alert(transform);
            }
        }
    }
}
