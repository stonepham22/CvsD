using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateMachine
{
    private IState _currentState;
    public IState CurrentState => _currentState;
    private IdleState _idleState;
    public IdleState IdleState => _idleState;
    private WalkState _walkState;
    public WalkState WalkState => _walkState;
    private DeadState _deadState;
    public DeadState DeadState => _deadState;
    
    public StateMachine(Animator animator)
    {
        _idleState = new IdleState(animator);
        _walkState = new WalkState(animator);
        _deadState = new DeadState(animator);
    }

    public void Initialize(IState state)
    {
        _currentState = state;
        state.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        _currentState?.Exit();
        _currentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        _currentState?.Update();
    }
}