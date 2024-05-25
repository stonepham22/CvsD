using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSendCoin : BaseDogSendReward, IObserverListener
{
    [Header("Dog Send Coin")]

    [SerializeField] private int _coinDefault = 1;

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.DogOnDead, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        if (transform.parent != (Transform)data) return;
        this.SendCoin();
    }

    public void SendCoin()
    {
        int coin = this.scale * this._coinDefault;
        ObserverManager.Instance.NotifyEvent(EventType.IncreaseCoin, coin);
    }    

}
