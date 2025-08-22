// 8/22/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity.AI.Assistant.Agent.Dynamic.Extension.Editor
{
   
    internal class CommandScript : MonoBehaviour
    {
        [Header("Movement Settings")]
        
        public float walkSpeed = 5f;
        
        public float runSpeed = 10f;
        
        public float jumpForce = 5f;
        [Header("Ground Check")]
        
        public Transform groundCheckPoint;
        
        public float groundCheckRadius = 0.2f;
        
        public LayerMask groundLayer;
        private Rigidbody rb;
        private Vector2 moveInput;
        private bool isRunning;
        private bool jumpInput;
        private bool isGrounded;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            // Get movement input
            moveInput = context.ReadValue<Vector2>();
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            // Check if running
            isRunning = context.performed;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            // Check if jump is triggered
            if (context.performed)
            {
                jumpInput = true;
            }
        }

        private void FixedUpdate()
        {
            // Check if the character is on the ground
            isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);
            // Calculate movement velocity
            float speed = isRunning ? runSpeed : walkSpeed;
            Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
            rb.linearVelocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);
            // Handle jumping
            if (jumpInput && isGrounded)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
                jumpInput = false; // Reset jump input
            }
        }

        private void OnDrawGizmosSelected()
        {
            // Visualize ground check in the editor
            if (groundCheckPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
            }
        }

       
    }
}