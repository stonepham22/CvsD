using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenDamageReceiver : DamageReceiver
{

    protected override void OnDead()
    {
        ObserverManager.Instance.NotifyEvent(EventType.ChickenOnDead, transform.parent.gameObject);
    }

}
