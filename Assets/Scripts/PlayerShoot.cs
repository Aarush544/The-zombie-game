using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate, bulletDamage;
    public bool isAuto;

    [Header("Initial Setup")]

    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;


    // Update is called once per frame
    private void Update()
    {
        if (isAuto)
        {
            if (Mouse.current.leftButton.IsPressed())
            {
                Shoot();
            }
        }
        else
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("bullet holder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);

    }
}
