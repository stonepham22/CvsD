using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingMenu : MonoBehaviour, IObserverListener
{
    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.OnClickExitShoppingMenuButton, this);
        ObserverManager.Instance.RegisterEvent(EventType.EnableShoppingMenu, this);
        transform.gameObject.SetActive(false);
    }
    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.OnClickExitShoppingMenuButton) transform.gameObject.SetActive(false);
        else transform.gameObject.SetActive(true);
    }

   
}
