using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float lookSpeed = 2f;

    public KeyCode moveForwardKey = KeyCode.W;
    public KeyCode moveBackwardKey = KeyCode.S;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveLeftKey = KeyCode.A;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = transform;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
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
        transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = -Input.GetAxis("Mouse Y") * lookSpeed;

        // Rotate the player horizontally
        playerTransform.Rotate(Vector3.up, mouseX);

        // Rotate the camera vertically
        Camera playerCamera = GetComponentInChildren<Camera>();
        playerCamera.transform.Rotate(Vector3.right, mouseY);
    }
}
