using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private CanFall canFall;
    [SerializeField] private IceSkatingMovement movementScript;
    [SerializeField] private GameObject iceCuttingTrail;
    //Camera script

    private void Start()
    {
        if (canFall != null)
        {
            canFall.Falling += Death;
        }
    }

    private void Death()
    {
        movementScript.StopMovement();
        iceCuttingTrail.SetActive(false);
        //Stop camera follow
    }
}
