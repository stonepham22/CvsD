using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimation : LoboMonoBehaviour
{
    
    [SerializeField] protected Animator animator;
    protected const string IS_DEAD = "isDead";
    protected const string IS_ATTACK = "isAttack";

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    private void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }
}
