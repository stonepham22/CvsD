using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveText : BaseText
{

    [SerializeField] private int _wave = 0;
    public int Wave => _wave;

    public void UpdateWaveText(int wave)
    {
        this._wave = wave;
        this.ShowWaveText();
    }
    
    public void ShowWaveText()
    {
        this.ShowText(_wave.ToString());
    }

}
