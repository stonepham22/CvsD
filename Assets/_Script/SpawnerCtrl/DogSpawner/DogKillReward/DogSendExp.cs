using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSendExp : BaseDogSendReward, IObserverListener
{
    [Header("Dog Send Exp")]

    [SerializeField] private int expDefault = 10;

    private void Start()
    {
        this.RegisterEventDogOnDead();
    }

    public void NotifyEvent(EventType type, object data)
    {
        if (transform.parent != (Transform)data) return;
        this.SendExp();
    }

    private void RegisterEventDogOnDead()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
    }

    public void SendExp()
    {
        int expSend = this.scale * this.expDefault;
        ObserverManager.Instance.NotifyEvent(EventType.DogSendExpToPlayer, expSend);
    }

}
