using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSendCoin : BaseDogSendReward, IObserverListener
{
    [Header("Dog Send Coin")]

    [SerializeField] private int _coinDefault = 1;

    private void Start()
    {
        this.RegisterEventDogOnDead();
    }

    public void NotifyEvent(EventType type, object data)
    {
        if (transform.parent != (Transform)data) return;
        this.SendCoin();
    }

    private void RegisterEventDogOnDead()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
    }

    public void SendCoin()
    {
        int coin = this.scale * this._coinDefault;
        ObserverManager.Instance.NotifyEvent(EventType.IncreaseCoin, coin);
    }    

}
