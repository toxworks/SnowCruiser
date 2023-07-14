using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    public Transform vehicle; // assign the vehicle in the Inspector
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // check if player is inside the vehicle
        if (transform.parent == vehicle)
        {
            // allow player to move inside the vehicle
            float x = Input.GetAxis("Horizontal") * Time.deltaTime;
            float z = Input.GetAxis("Vertical") * Time.deltaTime;
            Vector3 move = transform.right * x + transform.forward * z;
            transform.localPosition += move;

            // check if player wants to exit the vehicle
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExitVehicle();
            }
        }
        else
        {
            // check if player wants to enter the vehicle
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterVehicle();
            }
        }
    }

    void EnterVehicle()
    {
        transform.parent = vehicle;
        characterController.enabled = false;
    }

    void ExitVehicle()
    {
        transform.parent = null;
        characterController.enabled = true;
    }
}
