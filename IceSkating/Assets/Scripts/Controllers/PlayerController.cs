using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private IceSkatingMovement movementScript;
    [SerializeField] private CharacterStats stats;

    private void Update()
    {
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        if (Input.touchCount > 0)
        {
            Vector2 dp = Input.GetTouch(0).deltaPosition;

            if (dp.magnitude > stats.inputThreshold)
            {
                movementScript.SetTargetRotation(dp);
            }
        }
    }
}
