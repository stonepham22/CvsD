using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExp : BaseSlider, IObserverListener
{

    protected override void Start()
    {
        base.Start();
        ManagerCtrl.Instance.Observer.Register(EventType.ShowExp, this);
    }

    public void NotifyEvent(object data)
    {
        float value = (float)data;
        this.ShowExpSlider(value);
    }

    private void ShowExpSlider(float newValue)
    {
        this.OnChanged(newValue);
    }

}
