using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonController : MonoBehaviour
    {
        public float speed = 5f;
        public float mouseSensitivity = 2f;
        public Transform cameraTransform;
        public float jumpHeight = 1.2f;
        public float gravity = -9.81f;

        public float jumpCooldown = 0.5f; // Jump cooldown duration in seconds
        private float jumpCooldownTimer = 0f; // Timer to track the remaining cooldown time

        private float xRotation = 0f;
        private float verticalVelocity;
        private CharacterController controller;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Move();
            CameraRotation();
            JumpAndGravity();
        }

private void Move()
{
    Vector2 moveInput = new Vector2(
        Keyboard.current.aKey.isPressed ? -1f : Keyboard.current.dKey.isPressed ? 1f : 0f,
        Keyboard.current.sKey.isPressed ? -1f : Keyboard.current.wKey.isPressed ? 1f : 0f
    );

    Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
    moveDirection.Normalize();
    controller.Move(moveDirection * speed * Time.deltaTime);
}


        private void CameraRotation()
        {
            Vector2 lookInput = Mouse.current.delta.ReadValue() * mouseSensitivity * Time.deltaTime;
            xRotation -= lookInput.y;
            xRotation = Mathf.Clamp(xRotation, -85f, 85f);
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * lookInput.x);
        }

        private void JumpAndGravity()
        {
            if (controller.isGrounded)
            {
                verticalVelocity = -2f;
                if (Keyboard.current.spaceKey.wasPressedThisFrame && jumpCooldownTimer <= 0f)
                {
                    verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
                    jumpCooldownTimer = jumpCooldown;
                }
            }
            else
            {
                jumpCooldownTimer = 0f; // Reset the cooldown if the player is not grounded
            }

            if (jumpCooldownTimer > 0f)
            {
                jumpCooldownTimer -= Time.deltaTime;
            }

            verticalVelocity += gravity * Time.deltaTime;
            controller.Move(new Vector3(0f, verticalVelocity, 0f) * Time.deltaTime);
        }
    }
}
