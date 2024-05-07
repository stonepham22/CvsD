using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonOn : BaseButton
{

    protected override void OnClick()
    {
        base.OnClick();
        ObserverManager.Instance.NotifyEvent(EventType.ShoppingMenu, true);
        Debug.Log("ShopButtonOn");
    }

}
