using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSendCoin : BaseDogSendReward, IObserverListener
{
    [Header("Dog Send Coin")]

    [SerializeField] private int _coinDefault = 1;

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
        if (transform.parent == dogData.dogPrefab.transform) this.SendCoin();
    }

    public void SendCoin()
    {
        int coin = this.scale * this._coinDefault;
        ObserverManager.Instance.NotifyEvent(EventType.IncreaseCoin, coin);
    }    

}
