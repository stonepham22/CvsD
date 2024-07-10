using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private Animator _animator;
    private const string IS_IDLE = "isIdle";
    public IdleState(Animator animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.SetBool(IS_IDLE, true);
    }
    public void Update()
    {
        
    }
    public void Exit()
    {
        _animator.SetBool(IS_IDLE, false);
    }
}