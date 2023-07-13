using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;

    public KeyCode moveForwardKey = KeyCode.W;
    public KeyCode moveBackwardKey = KeyCode.S;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveLeftKey = KeyCode.A;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    private float speedMultiplier = 1f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 inputDirection = GetInputDirection();
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float movementSpeed = isRunning ? runSpeed * speedMultiplier : walkSpeed * speedMultiplier;

        moveDirection = CalculateMovementDirection(inputDirection, movementSpeed);

        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpPower;
            }
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private Vector3 GetInputDirection()
    {
        Vector3 direction = new Vector3(
            GetInputAxis(moveRightKey, moveLeftKey),
            0f,
            GetInputAxis(moveForwardKey, moveBackwardKey)
        );
        direction.Normalize();
        return direction;
    }

    private float GetInputAxis(KeyCode positiveKey, KeyCode negativeKey)
    {
        float positiveInput = Input.GetKey(positiveKey) ? 1f : 0f;
        float negativeInput = Input.GetKey(negativeKey) ? -1f : 0f;
        return positiveInput + negativeInput;
    }

    private Vector3 CalculateMovementDirection(Vector3 inputDirection, float speed)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        return (forward * inputDirection.z + right * inputDirection.x) * speed;
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }

    public void ResetSpeedMultiplier()
    {
        speedMultiplier = 1f;
    }
}
