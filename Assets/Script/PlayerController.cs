// 8/22/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 5f;

    private Rigidbody _rb;
    private Vector2 moveInput;
    private bool isRunning;
    private bool jumpInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // L?y gi� tr? di chuy?n (Vector2)
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        // Ki?m tra tr?ng th�i ch?y
        isRunning = context.performed;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Ki?m tra tr?ng th�i nh?y
        if (context.performed)
        {
            jumpInput = true;
        }
    }

    private void FixedUpdate()
    {
        // Tinh toan van toc di chuyen
        float speed = isRunning ? runSpeed : walkSpeed;
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        _rb.linearVelocity = new Vector3(moveDirection.x * speed, _rb.linearVelocity.y, moveDirection.z * speed);

        // Xu ly nhay
        if (jumpInput && IsGrounded())
        {
            Debug.Log(IsGrounded());
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, jumpForce, _rb.linearVelocity.z);
            jumpInput = false; // Reset trang thai nhay
        }
    }

    private bool IsGrounded()
    {
        // Kiem tra xem nhan vat co dung tren mat dat khong
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}