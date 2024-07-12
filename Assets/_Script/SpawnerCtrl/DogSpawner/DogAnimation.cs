using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimation : BaseAnimation, IObserverListener
{
    private AnimationStateMachine _animationStateMachine;
    private void OnEnable()
    {
        RegistEvent();
    }
    private void Start()
    {
        InitStateMachine();
    }
    private void OnDisable()
    {
        UnregisterEvent();
    }

    private void RegistEvent()
    {
        List<EventType> types = new List<EventType>()
        {
            EventType.DogTriggerEnter,
            EventType.DogTriggerExit,
            EventType.DogOnDead,

            EventType.OnClickShoppingButtonOn,
            EventType.ExitShoppingMenu,
            
        };
        ObserverManager.Instance?.RegistEvent(types, this);
    }
    private void UnregisterEvent()
    {
        List<EventType> types = new List<EventType>()
        {
            EventType.DogTriggerEnter,
            EventType.DogTriggerExit,
            EventType.DogOnDead,

            EventType.OnClickShoppingButtonOn,
            EventType.ExitShoppingMenu,
            
        };
        ObserverManager.Instance?.UnregistEvent(types, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        switch (type)
        {
            
            case EventType.DogTriggerEnter:
                HandleDogAnimation(data, _animationStateMachine.AttackState);
                break;
            case EventType.DogTriggerExit:
                HandleDogAnimation(data, _animationStateMachine.WalkState);
                break;
            case EventType.DogOnDead:
                HandleDogAnimation(data, _animationStateMachine.DeadState);
                break;
            
            case EventType.OnClickShoppingButtonOn:
                TransitionTo(_animationStateMachine.IdleState);
                break;
            case EventType.ExitShoppingMenu:
                TransitionTo(_animationStateMachine.WalkState);
                break;

        }
    }
    private void HandleDogAnimation(object data, IState state)
    {
        if (data is not DogData dogData) return;
        if (transform.parent == dogData.dogPrefab.transform)
        {
            TransitionTo(state);
        }
    }

    private void InitStateMachine()
    {
        _animationStateMachine = new AnimationStateMachine(animator);
    }
    private void TransitionTo(IState state)
    {
        _animationStateMachine.TransitionTo(state);
    }
}
