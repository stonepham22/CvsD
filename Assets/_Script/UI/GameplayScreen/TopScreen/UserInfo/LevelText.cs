using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : BaseText, IObserverListener
{

    private void Start()
    {
        this.RegisterEventShowLevel();
    }

    public void NotifyEvent(object data)
    {
        int level = (int)data;
        this.ShowLevel(level);
    }

    private void RegisterEventShowLevel()
    {
        ManagerCtrl.Instance.Observer.RegisterEvent(EventType.ShowLevel, this);
    }    

    private void ShowLevel(int level)
    {
        this.text.text = level.ToString();
    }
    
}
