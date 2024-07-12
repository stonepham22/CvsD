using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private Animator _animator;
    private const string IS_ATTACK = "isAttack";
    
    public AttackState(Animator animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        this._animator.SetBool(IS_ATTACK, true);
    }
    public void Update() { }
    public void Exit()
    {
        this._animator.SetBool(IS_ATTACK, false);
    }
}