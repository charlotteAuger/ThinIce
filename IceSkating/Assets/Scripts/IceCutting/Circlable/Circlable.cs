using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Circlable : MonoBehaviour
{
    [SerializeField] protected float pointsValue;
    [SerializeField] protected Rigidbody rB;

    public virtual void Swallowed()
    {
        /*if (rB != null)
        {
            rB.isKinematic = true;
        }*/

        GameManager.Instance.GainPoints(pointsValue);
    }
}
