using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : BaseShoppingButton
{

    protected override void Start()
    {
        base.Start();
        this.NotifyEventDisableShoppingMenu();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.index = 1;
    }

    private void NotifyEventDisableShoppingMenu()
    {
        ObserverManager.Instance.NotifyEvent(EventType.DisableShoppingMenu, null);
    }

}
