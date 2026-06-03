using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    public float MovementSpeed = 10f;
    public float RotationSpeed = 7f;

    public float JumpForce = 10f;
    public float Gravity = -30f;
    public Transform cameraPivot;
    private float _rotationX;
    private float _rotationY;
    private float _verticalVelocity;

    public float health = 100f;

    public float SprintSpeed = 15f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 movementVector, bool isSprinting)
    {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        float speed = isSprinting && SprintSpeed > 0f ? SprintSpeed : MovementSpeed;
        move *= speed * Time.deltaTime;
        _characterController.Move(move);
        _verticalVelocity = _verticalVelocity + Gravity * Time.deltaTime;
        _characterController.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);
    }

    public void Rotate(Vector2 rotationVector)
    {
        _rotationX -= rotationVector.y * RotationSpeed * Time.deltaTime;
        _rotationY += rotationVector.x * RotationSpeed * Time.deltaTime;
        
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0f, _rotationY, 0f);
        cameraPivot.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);

    }

    public void Jump(bool isSprinting){
        if (_characterController.isGrounded){
            _verticalVelocity = JumpForce;
            if (isSprinting) {
                _verticalVelocity += 10;
            }
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy")) {
            health -= 20;
            if (health <= 0) {
                
            }
        }
    }
}
