using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    private Animator _animator;
    private const string IS_DEAD = "isDead";
    public DeadState(Animator animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.SetBool(IS_DEAD, true);
    }
    public void Update()
    {

    }
    public void Exit()
    {
        _animator.SetBool(IS_DEAD, false);
    }
}
