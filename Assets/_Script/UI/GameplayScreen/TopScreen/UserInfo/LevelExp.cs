using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExp : BaseSlider, IObserverListener
{

    protected override void Start()
    {
        base.Start();
        this.RegisteredEvents();
    }

    private void RegisteredEvents()
    {
        ObserverManager.Instance.RegistEvent(EventType.LevelUp, this);
        ObserverManager.Instance.RegistEvent(EventType.ShowExp, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        if(data is float value)
        {
            this.ShowExpSlider(value);
        }
    }

    private void ShowExpSlider(float newValue)
    {
        this.OnChanged(newValue);
    }

}
