// 8/22/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 50f; // Speed of rotation in degrees per second

    void Update()
    {
        // Check if the left arrow key is pressed
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            // Rotate the object slowly to the left (negative Y-axis rotation)
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        // Check if the right arrow key is pressed
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            // Rotate the object slowly to the right (positive Y-axis rotation)
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}