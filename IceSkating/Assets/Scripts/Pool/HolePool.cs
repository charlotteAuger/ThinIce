using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolePool : Poolable
{
    [SerializeField] private GameObject iceBlock;
    [SerializeField] private Animator animator;
    [SerializeField] private SafetyWindow safety;


    public override void Spawn()
    {
        base.Spawn(); 

        iceBlock.SetActive(true);
        StartCoroutine("StartAnim");
        safety.StartWindow();

        

    }

    IEnumerator StartAnim()
    {
        yield return null;
        animator.SetTrigger("Reset");
    }

    public override void Disable()
    {
        base.Disable();
        LevelGenerator.instance.RemoveElement(this);
    }
}
