using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShoppingMenuButton : BaseButton
{
    protected override void OnClick()
    {
        ObserverManager.Instance.NotifyEvent(EventType.ExitShoppingMenu, this);
    }

}
