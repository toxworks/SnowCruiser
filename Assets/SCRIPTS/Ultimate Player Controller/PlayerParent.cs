using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    public Transform vehicle; // assign the vehicle in the Inspector
    public MonoBehaviour script1; // assign in the Inspector
    public MonoBehaviour script2; // assign in the Inspector

    void Start()
    {
        script1.enabled = false;
        script2.enabled = true;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            if (transform.parent == vehicle)
            {
                ExitVehicle();
                script1.enabled = false;
                script2.enabled = true;
            }
            else
            {
                EnterVehicle();
                script1.enabled = true;
                script2.enabled = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            if (transform.parent == vehicle)
            {
                ExitVehicle();
                script1.enabled = false;
                script2.enabled = true;
            }
        }
    }

    void EnterVehicle()
    {
        transform.parent = vehicle;
    }

    void ExitVehicle()
    {
        transform.parent = null;
        Vector3 euler = transform.eulerAngles;
        euler.z = 0f;
        transform.eulerAngles = euler;
    }
}
