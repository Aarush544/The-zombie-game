using System.Numerics;
using System.Threading.Tasks.Dataflow;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private ChaacterController _characterController;
    public float MovementSpeed = 10f, RotationSpeed = 5f;
    private float _rotationY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void Move()
    {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * MovementSpeed * Time.deltaTime;
        _characterController.Move(move);
    }

    public void Rotate(Vector2 rotationVector)
    {
        _rotationY += rotationVector.x * RotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }
}
