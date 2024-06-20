using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPriceText : BaseText, IObserverListener
{
    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.OnClickShoppingMenuItemButton, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        if(transform.parent.parent.gameObject != ((ItemButtonData)data).itemPrefab) return;
        this.ShowItemPrice(((ItemButtonData)data).itemPriceCur);
    }
    public void ShowItemPrice(int itemPrice)
    {
        this.text.text = itemPrice.ToString();
    }
}
