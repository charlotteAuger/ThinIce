using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwallowCirclable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Circlable c = other.gameObject.GetComponent<Circlable>();
        if (c != null)
        {
            other.transform.parent = transform;
            other.enabled = false;

            c.Swallowed();
        }
    }

    public void DestroyElement()
    {
        Destroy(gameObject);
    }
}
       
