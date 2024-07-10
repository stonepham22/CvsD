using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingMenu : MonoBehaviour, IObserverListener
{
    private void Start()
    {
        this.RegistEvent();
        transform.gameObject.SetActive(false);
    }

    private void RegistEvent()
    {
        ObserverManager.Instance.RegistEvent(EventType.OnClickShoppingButtonOn, this);
        ObserverManager.Instance.RegistEvent(EventType.ExitShoppingMenu, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        switch(type)
        {
            case EventType.ExitShoppingMenu:
                transform.gameObject.SetActive(false);
                break;
            default:
                transform.gameObject.SetActive(true);
                break;
        }
    }
}
