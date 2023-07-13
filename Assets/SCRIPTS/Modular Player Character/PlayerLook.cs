using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    private float rotationX = 0f;
    private Transform playerCamera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera = GetComponentInChildren<Camera>().transform;
    }

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = -Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX += mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        transform.Rotate(Vector3.up * mouseX);
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
