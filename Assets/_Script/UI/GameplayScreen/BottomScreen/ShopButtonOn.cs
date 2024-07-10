using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonOn : BaseButton
{

    protected override void OnClick()
    {
        this.NotifyEventOnClick();
    }

    private void NotifyEventOnClick()
    {
        ObserverManager.Instance.NotifyEvent(EventType.OnClickShoppingButtonOn, this);
    }

}
