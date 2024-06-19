using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemButtonOff : LoboMonoBehaviour, IObserverListener
{
    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.ItemLevelGatherThanPlayerLevel, this);
        ObserverManager.Instance.RegisterEvent(EventType.ItemCoinGatherThanPlayerCoin, this);
    }
    
    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.ItemLevelGatherThanPlayerLevel)
            transform.gameObject.SetActive(false);
        else transform.gameObject.SetActive(true);
    }

    
}
