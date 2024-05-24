using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPriceTextButtonOff : BaseText, IObserverListener
{

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DisableChickenButtonOn, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        int chickenPrice = (int)data;
        ShowChickenPrice(chickenPrice);
    }

    private void ShowChickenPrice(int price)
    {
        this.text.text = price.ToString();
    }

    
}
