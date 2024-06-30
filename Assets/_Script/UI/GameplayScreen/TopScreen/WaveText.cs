using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveText : BaseText, IObserverListener
{
    private void Start()
    {
        ObserverManager.Instance.RegistEvent(EventType.ShowWaveText, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        this.ShowWaveText((int)data);
    }

    private void ShowWaveText(int wave)
    {
        this.ShowText(wave.ToString());
    }

}
