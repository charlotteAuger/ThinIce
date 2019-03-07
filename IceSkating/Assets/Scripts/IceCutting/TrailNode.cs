using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailNode : MonoBehaviour
{
    private IceCuttingTrail owner;

    public void Initialization(IceCuttingTrail _owner, float lifeSpan)
    {
        owner = _owner;
        Invoke("AutoDestroy", lifeSpan);
    }

    private void AutoDestroy()
    {
        owner.RemoveNode(gameObject);
        Destroy(gameObject);
    }
}
