using UnityEngine;

public class VehicleCollisionOnOff : MonoBehaviour
{
    public Rigidbody vehicleRigidbody;
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            vehicleRigidbody.isKinematic = false;
        }
    }
}
