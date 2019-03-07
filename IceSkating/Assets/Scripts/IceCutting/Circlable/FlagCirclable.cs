using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCirclable : Circlable
{
    public float trailIncrementValue;

    public override void Swallowed()
    {
        base.Swallowed();

        GameManager.Instance.TrailUp(trailIncrementValue);
    }
}
