using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolePool : Poolable
{
    [SerializeField] private GameObject iceBlock;
    [SerializeField] private Animator animator;
    [SerializeField] private SafetyWindow safety;
    [SerializeField] private MeshRenderer rend;
    [SerializeField] private MeshRenderer depthMask;


    public override void Spawn()
    {
        base.Spawn();

        StartCoroutine("StartAnim");
        safety.StartWindow();
    }

    IEnumerator StartAnim()
    {
        rend.enabled = false;
        depthMask.enabled = false;
        iceBlock.SetActive(true);

        yield return null;

        animator.SetTrigger("Reset");
        iceBlock.SetActive(true);
        rend.enabled = true;
        depthMask.enabled = true;

    }

    public override void Disable()
    {
        base.Disable();
        LevelGenerator.instance.RemoveElement(this);
    }
}
