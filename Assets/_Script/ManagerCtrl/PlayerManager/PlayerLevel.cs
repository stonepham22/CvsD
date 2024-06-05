using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerLevel : LoboMonoBehaviour, IObserverListener
{

    [SerializeField] private int _level = 1;
    public int Level => _level;

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.LevelUp, this);
        this.LoadLevel();
        this.ShowLevel();
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.LevelUp, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        this.LevelUp();
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
