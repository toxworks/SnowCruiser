using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParenting : MonoBehaviour
{
    private bool isInsideVehicle = false;
    private Transform vehicleTransform;
    private Vector3 relativePosition;

    private void Update()
    {
        if (isInsideVehicle)
        {
            // Update the player's position relative to the vehicle
            transform.position = vehicleTransform.TransformPoint(relativePosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            // Store a reference to the vehicle's transform
            vehicleTransform = other.transform;

            // Calculate the relative position of the player within the vehicle
            relativePosition = vehicleTransform.InverseTransformPoint(transform.position);

            // Parent the player to the vehicle
            transform.parent = vehicleTransform;

            // Set the flag to indicate the player is inside the vehicle
            isInsideVehicle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            // Unparent the player from the vehicle
            transform.parent = null;

            // Clear the references and reset the flag
            vehicleTransform = null;
            relativePosition = Vector3.zero;
            isInsideVehicle = false;
        }
    }
}
