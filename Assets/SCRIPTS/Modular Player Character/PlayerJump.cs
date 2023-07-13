using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpPower = 7f;
    public float gravity = 10f;

    private CharacterController characterController;
    private float verticalSpeed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                verticalSpeed = CalculateJumpSpeed();
            }
            else
            {
                verticalSpeed = -gravity * Time.deltaTime;
            }
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        Vector3 movement = new Vector3(0f, verticalSpeed, 0f);
        characterController.Move(movement * Time.deltaTime);
    }

    private float CalculateJumpSpeed()
    {
        return Mathf.Sqrt(2f * jumpPower * gravity);
    }
}
