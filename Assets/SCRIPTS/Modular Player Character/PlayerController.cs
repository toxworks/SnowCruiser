using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    public KeyCode moveForwardKey = KeyCode.W;
    public KeyCode moveBackwardKey = KeyCode.S;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode jumpKey = KeyCode.Space;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;
    private bool isJumping = false;
    private bool isRunning = false;

    private CharacterController characterController;
    private Transform playerTransform; // Added reference to the player's transform

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerTransform = transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleJump();
        HandleRun();
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(moveForwardKey))
        {
            moveDirection += playerTransform.forward;
        }
        if (Input.GetKey(moveBackwardKey))
        {
            moveDirection -= playerTransform.forward;
        }
        if (Input.GetKey(moveRightKey))
        {
            moveDirection += playerTransform.right;
        }
        if (Input.GetKey(moveLeftKey))
        {
            moveDirection -= playerTransform.right;
        }

        // Normalize move direction to ensure consistent movement speed
        moveDirection.Normalize();

        // Apply movement
        playerTransform.position += moveDirection * (isRunning ? runSpeed : walkSpeed) * Time.deltaTime;
    }

    private void HandleRotation()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerTransform.rotation *= Quaternion.Euler(0f, Input.GetAxis("Mouse X") * lookSpeed, 0f);
    }

    private void HandleJump()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                isJumping = true;
            }
        }

        if (isJumping)
        {
            moveDirection.y = jumpPower;
            isJumping = false;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void HandleRun()
    {
        isRunning = Input.GetKey(runKey);
    }
}
