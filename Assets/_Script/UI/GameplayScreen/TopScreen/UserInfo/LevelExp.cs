using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExp : BaseSlider, IObserverListener
{

    protected override void Start()
    {
        base.Start();
        ObserverManager.Instance.RegisterEvent(EventType.LevelUp, this);
        ObserverManager.Instance.RegisterEvent(EventType.ShowExp, this);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.LevelUp, this);
        ObserverManager.Instance.UnregisterEvent(EventType.ShowExp, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        float value = (float)data;
        this.ShowExpSlider(value);
    }

    private void ShowExpSlider(float newValue)
    {
        this.OnChanged(newValue);
    }

}
