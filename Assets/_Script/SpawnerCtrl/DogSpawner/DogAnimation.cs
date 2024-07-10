using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimation : BaseAnimation, IObserverListener
{
    private StateMachine _stateMachine;
    private void OnEnable()
    {
        RegistEvent();
    }
    private void Start()
    {
        CreateStateMachine();
    }
    private void OnDisable()
    {
        UnregisterEvent();
    }

    private void RegistEvent()
    {
        List<EventType> types = new List<EventType>()
        {
            EventType.DogOnDead,
            EventType.OnClickShoppingButtonOn,
            EventType.ExitShoppingMenu
        };
        ObserverManager.Instance?.RegistEvent(types, this);
    }
    private void UnregisterEvent()
    {
        List<EventType> types = new List<EventType>()
        {
            EventType.DogOnDead,
            EventType.OnClickShoppingButtonOn,
            EventType.ExitShoppingMenu
        };
        ObserverManager.Instance?.UnregistEvent(types, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        switch(type)
        {
            case EventType.DogOnDead:
                HandleDogOnDead(data);
                break;
            case EventType.OnClickShoppingButtonOn:
                HandleOnClickShoppingButtonOn();
                break;
            default:
                HandleExitShoppingMenu();
                break;
        }
    }
    private void HandleDogOnDead(object data)
    {
        if (data is not DogData dogData) return;
        if (transform.parent == dogData.dogPrefab.transform) this.SetDead();
    }
    private void HandleOnClickShoppingButtonOn()
    {
        _stateMachine.TransitionTo(_stateMachine.IdleState);
    }
    private void HandleExitShoppingMenu()
    {
        _stateMachine.TransitionTo(_stateMachine.WalkState);
    }

    private void SetDead()
    {
        this.animator.SetBool(IS_DEAD, true);
    }
    public void SetAttack(bool value)
    {
        this.animator.SetBool(IS_ATTACK, value);
    }
    private void CreateStateMachine()
    {
        _stateMachine = new StateMachine(animator);
    }
}
