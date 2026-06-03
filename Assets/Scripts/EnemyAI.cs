using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 12f;
    public Transform targetPlayer;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        targetPlayer = playerObject.transform;
    }

    void Update()
    {  
        Vector3 targetPosition = targetPlayer.position;
        targetPosition.y = transform.position.y;
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 move = direction * moveSpeed * Time.deltaTime;
        
        if (_rigidbody != null)
        {
            _rigidbody.MovePosition(transform.position + move);
        }
        else
        {
            transform.position += move;
        }

        transform.LookAt(targetPosition);
    }

    public void Alert(Transform player)
    {
        targetPlayer = player;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            
        }

    } 
}
