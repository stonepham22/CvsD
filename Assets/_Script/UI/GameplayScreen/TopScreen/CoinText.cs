using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinText : BaseText, IObserverListener
{

    private void Start()
    {
        this.RegisterEventShowCoin();
    }

    public void NotifyEvent(object data)
    {
        int coin = (int)data;
        this.ShowCoin(coin);
    }

    private void RegisterEventShowCoin()
    {
        ManagerCtrl.Instance.Observer.RegisterEvent(EventType.ShowCoin, this);
    }

    private void ShowCoin(int coin)
    {
        this.text.text = coin.ToString();
    }

   
}
