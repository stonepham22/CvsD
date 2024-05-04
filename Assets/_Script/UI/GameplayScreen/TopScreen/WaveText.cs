using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveText : BaseText, IObserverListener
{

    [SerializeField] private int _wave = 1;
    public int Wave => _wave;

    private void Start()
    {
        ManagerCtrl.Instance.Observer.Register(EventType.ShowWaveText, this);
    }

    public void NotifyEvent(object data)
    {
        this.UpdateWaveText();
    }

    private void UpdateWaveText()
    {
        this._wave++;
        this.ShowWaveText();
    }
    
    private void ShowWaveText()
    {
        this.ShowText(_wave.ToString());
    }

}
