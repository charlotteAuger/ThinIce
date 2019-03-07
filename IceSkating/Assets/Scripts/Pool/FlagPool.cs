using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPool : Poolable
{
    [SerializeField] private Collider c;

    public override void Spawn()
    {
        base.Spawn();
        c.enabled = true;
    }

    public override void Disable()
    {
        base.Disable();
        LevelGenerator.instance.RemoveElement(this);
    }
}
