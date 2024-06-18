using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemButtonOff : LoboMonoBehaviour, IObserverListener
{
    private void OnEnable()
    {
        ObserverManager.Instance.RegisterEvent(EventType.OnClickShoppingMenuItemButton, this);
    }

    private void Start()
    {
        transform.gameObject.SetActive(false);
    }
    public void NotifyEvent(EventType type, object data)
    {
        
    }
}
