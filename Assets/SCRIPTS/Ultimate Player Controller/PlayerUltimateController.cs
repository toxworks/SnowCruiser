using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimateController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    private CameraController cameraController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraController = GetComponent<CameraController>();
    }

    void Update()
    {
        Move();
        cameraController.UpdateCameraRotation();
    }

    private void Move()
    {
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
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
