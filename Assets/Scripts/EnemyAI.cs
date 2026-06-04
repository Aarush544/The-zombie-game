using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 12f;
    private Transform targetPlayer;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (targetPlayer == null)
            return;

        Vector3 targetPosition = targetPlayer.position;
        targetPosition.y = transform.position.y;
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 move = direction * moveSpeed * Time.deltaTime;
        
        
        _rigidbody.MovePosition(transform.position + move);

        transform.LookAt(targetPosition);
    }

    public void Alert(Transform player)
    {
        targetPlayer = player;
    }
}
