using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine
{
    protected IState currentState;
    public IState CurrentState => currentState;

    public virtual void Initialize(IState state)
    {
        currentState = state;
        state.Enter();
    }

    public virtual void TransitionTo(IState nextState)
    {
        currentState?.Exit();
        currentState = nextState;
        nextState.Enter();
    }

    public virtual void Update()
    {
        currentState?.Update();
    }
}
