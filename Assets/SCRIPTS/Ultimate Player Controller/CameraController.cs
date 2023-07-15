using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lookSensitivity = 2f;
    public Transform cameraTransform;

    private float xRotation = 0f;

    public void UpdateCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;
        RotateCamera(mouseX, mouseY);
    }

    public void RotateCamera(float mouseX, float mouseY)
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
