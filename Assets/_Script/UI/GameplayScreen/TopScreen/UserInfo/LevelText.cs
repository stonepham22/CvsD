using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : BaseText, IObserverListener
{

    private void Start()
    {
        this.RegisterEventShowLevel();
    }

    public void NotifyEvent(EventType type, object data)
    {
        int level = (int)data;
        this.ShowLevel(level);
    }

    private void RegisterEventShowLevel()
    {
        ObserverManager.Instance.RegisterEvent(EventType.ShowLevel, this);
    }    

    private void ShowLevel(int level)
    {
        this.text.text = level.ToString();
    }
    
}
