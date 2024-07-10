using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    private Animator _animator;
    public DeadState(Animator animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        
    }


    public void Update()
    {

    }
    public void Exit()
    {

    }
}
