using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinText : BaseText, IObserverListener
{

    private void OnEnable()
    {
        ObserverManager.Instance.RegistEvent(EventType.ShowCoin, this);
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

}
