using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimation : BaseDogPrefab, IObserverListener
{
    [SerializeField] private const string IS_DEAD = "isDead";
    [SerializeField] private const string IS_ATTACK = "isAttack";

    private void Start()
    {
        this.RegisterEventDogOnDead();
    }

    public void NotifyEvent(EventType type, object data)
    {
        if (transform.parent != (Transform)data) return;
        this.SetDead();
    }

    private void RegisterEventDogOnDead()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
    }

    private void SetDead()
    {
        this.dogPrefabCtrl.Animator.SetBool(IS_DEAD, true);
    }

    public void SetAttack(bool value)
    {
        this.dogPrefabCtrl.Animator.SetBool(IS_ATTACK, value);
    }
    
}
