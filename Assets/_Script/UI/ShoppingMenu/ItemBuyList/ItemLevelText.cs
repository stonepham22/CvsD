using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemLevelText : BaseText, IObserverListener
{

    // private void OnEnable()
    // {
    //     ObserverManager.Instance.RegisterEvent(EventType.OnClickShoppingMenuItemButton, this);
    // }

    // private void OnDisable()
    // {
    //     ObserverManager.Instance.UnregisterEvent(EventType.OnClickShoppingMenuItemButton, this);
    // }

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.OnClickShoppingMenuItemButton, this);
    }
    
    public void NotifyEvent(EventType type, object data)
    {
        if(transform.parent.gameObject != ((ItemButtonData)data).itemPrefab) return;
        this.ShowItemLevel(((ItemButtonData)data).itemLevel);    
    }    
    
    public void ShowItemLevel(int itemLevel)
    {
        this.ShowText("Level " + itemLevel);
    }

    
}
