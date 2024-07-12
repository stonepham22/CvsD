using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationStateMachine : BaseStateMachine
{
    private IdleState _idleState;
    public IdleState IdleState => _idleState;
    private AttackState _attackState;
    public AttackState AttackState => _attackState;
    private DeadState _deadState;
    public DeadState DeadState => _deadState;
    private WalkState _walkState;
    public WalkState WalkState => _walkState;
    
    public AnimationStateMachine(Animator animator)
    {
        _idleState = new IdleState(animator);
        _attackState = new AttackState(animator);
        _deadState = new DeadState(animator);
        _walkState = new WalkState();
    }

}