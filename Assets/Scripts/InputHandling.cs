using System.Numerics;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandling : MonoBehaviour
{
    public PlayerController CharacterController;
    private InputAction _moveAction, _lookAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _sprintAction = InputSystem.actions.FindAction("Sprint");

        _jumpAction.performed += OnJumpPerformed;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        isSprinting = _sprintAction != null && _sprintAction.IsPressed();

        if (_moveAction != null)
        {
            Vector2 movementVector = _moveAction.ReadValue<Vector2>();
            playerController.Move(movementVector, isSprinting);
        }

        if (_lookAction != null)
        {
            Vector2 lookVector = _lookAction.ReadValue<Vector2>();
            playerController.Rotate(lookVector);
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (playerController != null)
        {
            playerController.Jump(isSprinting);
        }
    }   
}
