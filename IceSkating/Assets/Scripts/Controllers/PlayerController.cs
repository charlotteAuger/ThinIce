using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private IceSkatingMovement movementScript;
    [SerializeField] private CharacterStats stats;

    private Vector3 lastMousePosition;

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

        if (Input.GetMouseButton(0) && lastMousePosition != null)
        {
            Vector3 dp = Input.mousePosition - lastMousePosition;
            Vector2 v = new Vector2(dp.x, dp.y);

            if (v.magnitude > stats.inputThreshold)
            {
                movementScript.SetTargetRotation(v);
            }
        }

        lastMousePosition = Input.mousePosition;
    }
}
