using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinText : BaseText, IObserverListener
{

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.ShowCoin, this);
    }

    private void OnDestroy()
    {
        UnregisterEvent();
    }

    public void NotifyEvent(EventType type, object data)
    {
        int coin = (int)data;
        this.ShowCoin(coin);
    }

    private void ShowCoin(int coin)
    {
        this.text.text = coin.ToString();
    }

    public void UnregisterEvent()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.ShowCoin, this);
    }
}
