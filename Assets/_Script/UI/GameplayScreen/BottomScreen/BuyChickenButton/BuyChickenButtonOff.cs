using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyChickenButtonOff : LoboMonoBehaviour, IObserverListener
{
    public void NotifyEvent(EventType type, object data)
    {
        transform.gameObject.SetActive(true);
    }

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DisableChickenButtonOn, this);
    }

}
