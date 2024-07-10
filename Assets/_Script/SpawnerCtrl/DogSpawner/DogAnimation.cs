using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimation : BaseAnimation, IObserverListener
{
    private StateMachine stateMachine;
    
    private void OnEnable()
    {
        RegistEvent();
    }
    private void Start()
    {
        stateMachine = new StateMachine(animator);
        stateMachine.Initialize(stateMachine.walkState);
    }
    private void OnDisable()
    {
        UnregisterEvent();
    }

    private void RegistEvent()
    {
        ObserverManager.Instance.RegistEvent(EventType.DogOnDead, this);
        ObserverManager.Instance.RegistEvent(EventType.OnClickShoppingButtonOn, this);
    }
    private void UnregisterEvent()
    {
        if (ObserverManager.Instance == null) return;
        ObserverManager.Instance.UnregistEvent(EventType.DogOnDead, this);
        ObserverManager.Instance.UnregistEvent(EventType.OnClickShoppingButtonOn, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.DogOnDead) HandleDogOnDead(data);
        else HandleOnClickShoppingButtonOn(data);
    }

    private void HandleDogOnDead(object data)
    {
        DogData dogData = (DogData)data;
        if (transform.parent == dogData.dogPrefab.transform) this.SetDead();
    }
    private void HandleOnClickShoppingButtonOn(object data)
    {
        stateMachine.TransitionTo(stateMachine.idleState);
    }

    private void SetDead()
    {
        this.animator.SetBool(IS_DEAD, true);
    }
    public void SetAttack(bool value)
    {
        this.animator.SetBool(IS_ATTACK, value);
    }
}
