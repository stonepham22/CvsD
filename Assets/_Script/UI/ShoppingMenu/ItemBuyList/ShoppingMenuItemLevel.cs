using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingMenuItemLevel : BaseText, IObserverListener
{

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterEvent(EventType.OnClickShoppingMenuItemButton, this);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.OnClickShoppingMenuItemButton, this);    
    }
    
    public void NotifyEvent(EventType type, object data)
    {
        this.ShowItemLevel(((ItemButtonData)data).itemLevel);
    }

    private void ShowItemLevel(int itemLevel)
    {
        this.ShowText("Level " + itemLevel);
    }

}
