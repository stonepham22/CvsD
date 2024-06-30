using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : BaseText, IObserverListener
{

    private void Start()
    {
        ObserverManager.Instance.RegistEvent(EventType.ShowLevel, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        int level = (int)data;
        this.ShowLevel(level);
    }

    private void ShowLevel(int level)
    {
        this.text.text = level.ToString();
    }
    
}
