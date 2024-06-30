using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimation : BaseAnimation, IObserverListener
{
    
    private void OnEnable()
    {
        ObserverManager.Instance.RegistEvent(EventType.DogOnDead, this);
    }

    private void OnDisable()
    {
        if(ObserverManager.Instance == null) return;
        ObserverManager.Instance.UnregistEvent(EventType.DogOnDead, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        DogData dogData = (DogData)data;
        if (transform.parent == dogData.dogPrefab.transform) this.SetDead();
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
