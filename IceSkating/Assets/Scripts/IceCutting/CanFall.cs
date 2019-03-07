using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanFall : MonoBehaviour
{
    public delegate void FallEvent();
    public FallEvent Falling;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hole") 
        {
            this.gameObject.layer = LayerMask.NameToLayer("Falling");
            Falling();
        }
    }
}
