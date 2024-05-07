using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerLevel : BasePlayerManager, IObserverListener
{

    [SerializeField] private int _level = 1;
    public int Level => _level;

    private void Start()
    {
        this.LoadLevel();
        this.ShowLevel();
        this.RegisterEventLevelUp();
    }

    public void NotifyEvent(object data)
    {
        this.LevelUp();
    }

    private void RegisterEventLevelUp()
    {
        ObserverManager.Instance.RegisterEvent(EventType.LevelUp, this);
    }    

    private void LoadLevel()
    {
            
    }

    public void LevelUp()
    {
        this._level++;
        this.ShowLevel();
    }

    private void ShowLevel()
    {
        ObserverManager.Instance.NotifyEvent(EventType.ShowLevel, this._level);
    }    

}
