using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemButtonOff : LoboMonoBehaviour, IObserverListener
{
    private void Start()
    {
        this.RegisteredEvents();
    }

    private void RegisteredEvents()
    {
        ObserverManager.Instance.RegistEvent(EventType.ItemLevelGatherThanPlayerLevel, this);
        ObserverManager.Instance.RegistEvent(EventType.ItemCoinGatherThanPlayerCoin, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        switch (type)
        {
            case EventType.ItemLevelGatherThanPlayerLevel:
                this.HandleItemLevelGatherThanPlayerLevel();
                break;
            default:
                this.HandleItemLevelGatherThanPlayerCoin();
                break;
        }
    }
    private void HandleItemLevelGatherThanPlayerLevel()
    {
        transform.gameObject.SetActive(false);
    }
    private void HandleItemLevelGatherThanPlayerCoin()
    {
        transform.gameObject.SetActive(true);
    }

}
