using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Bullet hit: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit! Destroying: " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }      
        Destroy(gameObject);
    }
}
