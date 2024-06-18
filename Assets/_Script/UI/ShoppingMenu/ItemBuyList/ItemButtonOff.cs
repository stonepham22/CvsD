using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemButtonOff : LoboMonoBehaviour, IObserverListener
{
    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DisableShoppingMenuItemButton, this);
        transform.gameObject.SetActive(false);
    }
    public void NotifyEvent(EventType type, object data)
    {
        transform.gameObject.SetActive(true);
    }
}
