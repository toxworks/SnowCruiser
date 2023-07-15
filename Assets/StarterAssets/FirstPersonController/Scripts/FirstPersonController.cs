using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    [RequireComponent(typeof(CharacterController))]
    public class FirstPersonController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float gravity = -9.81f;

        private float verticalVelocity;
        private CharacterController controller;

        private CameraController cameraController;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            cameraController = GetComponent<CameraController>();
        }

        private void Update()
        {
            Move();
            cameraController.UpdateCameraRotation();
            ApplyGravity();
        }

        private void Move()
        {
            Vector2 moveInput = new Vector2(
                Keyboard.current.aKey.isPressed ? -1f : Keyboard.current.dKey.isPressed ? 1f : 0f,
                Keyboard.current.sKey.isPressed ? -1f : Keyboard.current.wKey.isPressed ? 1f : 0f
            );

            Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
            moveDirection.Normalize();
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        private void ApplyGravity()
        {
            if (controller.isGrounded)
            {
                verticalVelocity = -2f;
            }

            verticalVelocity += gravity * Time.deltaTime;
            controller.Move(new Vector3(0f, verticalVelocity, 0f) * Time.deltaTime);
        }
    }
}
