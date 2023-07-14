using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimateController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public float gravity = -9.81f;
    public Transform cameraTransform;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    private CharacterController characterController;
    private Vector3 velocity;
    private float xRotation = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        /*
        // old player movement - glitches player movement when carController.cs is pointed towards global X axis
        float x = 0f;
        float z = 0f;
        if (Input.GetKey(forwardKey))
            z += 1f;
        if (Input.GetKey(backwardKey))
            z -= 1f;
        if (Input.GetKey(leftKey))
            x -= 1f;
        if (Input.GetKey(rightKey))
            x += 1f;
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        */

        // player movement
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(forwardKey))
            moveDirection += transform.forward;
        if (Input.GetKey(backwardKey))
            moveDirection -= transform.forward;
        if (Input.GetKey(leftKey))
            moveDirection -= transform.right;
        if (Input.GetKey(rightKey))
            moveDirection += transform.right;
        moveDirection.Normalize();
        transform.position += moveDirection * speed * Time.deltaTime;

        // player look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // player gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
