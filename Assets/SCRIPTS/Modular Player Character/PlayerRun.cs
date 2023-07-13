using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public KeyCode runKey = KeyCode.LeftShift;
    public float runMultiplier = 1.5f;
    
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(runKey))
        {
            playerMovement.SetSpeedMultiplier(runMultiplier);
        }
        else
        {
            playerMovement.ResetSpeedMultiplier();
        }
    }
}
