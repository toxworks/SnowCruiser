using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimateController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
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
    }
}
