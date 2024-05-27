using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSendExp : BaseDogSendReward, IObserverListener
{
    [Header("Dog Send Exp")]

    [SerializeField] private int expDefault = 10;

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
    }

    private void OnDisable()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.DogOnDead, this);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.DogOnDead, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        DogData dogData = (DogData)data;
        if (transform.parent == dogData.dogPrefab.transform) this.SendExp();
    }

    public void SendExp()
    {
        int expSend = this.scale * this.expDefault;
        ObserverManager.Instance.NotifyEvent(EventType.DogSendExpToPlayer, expSend);
    }

}
