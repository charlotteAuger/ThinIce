using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwallowCirclable : MonoBehaviour
{
    private List<Poolable> swallowedObjects = new List<Poolable>();

    private void OnTriggerEnter(Collider other)
    {
        Circlable c = other.gameObject.GetComponent<Circlable>();
        if (c != null)
        {
            other.transform.parent = null;
            other.transform.parent = transform;
            other.enabled = false;
            swallowedObjects.Add(other.GetComponentInParent<Poolable>());
            c.Swallowed();
        }
    }

    public void DestroyElement()
    {

        foreach (Poolable p in swallowedObjects)
        {
            p.transform.parent = null;
            p.Disable();
        }

        swallowedObjects.Clear();

        gameObject.SetActive(false);
    }
}
       
