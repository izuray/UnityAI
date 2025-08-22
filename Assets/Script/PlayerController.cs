// 8/22/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("C�i ??t di chuy?n")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isRunning;
    private bool jumpInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        // T�nh to�n v?n t?c di chuy?n
        float speed = isRunning ? runSpeed : walkSpeed;
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.linearVelocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);

        // X? l� nh?y
        if (jumpInput && IsGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            jumpInput = false; // Reset tr?ng th�i nh?y
        }
    }

    private bool IsGrounded()
    {
        // Ki?m tra n?u nh�n v?t ?ang ??ng tr�n m?t ??t
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}