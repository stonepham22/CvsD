using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private Animator _animator;
    public IdleState(Animator animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.SetBool("isIdle", true);
    }
    public void Update()
    {
        
    }
    public void Exit()
    {
        _animator.SetBool("isIdle", false);
    }
}