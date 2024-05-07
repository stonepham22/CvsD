using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveText : BaseText, IObserverListener
{
    private void Start()
    {
        ManagerCtrl.Instance.Observer.RegisterEvent(EventType.ShowWaveText, this);
    }

    public void NotifyEvent(object data)
    {
        this.ShowWaveText((int)data);
    }

    private void ShowWaveText(int wave)
    {
        this.ShowText(wave.ToString());
    }

}
