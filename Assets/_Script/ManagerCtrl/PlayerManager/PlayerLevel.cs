using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
public delegate void GetPlayerLevelDelegate(int playerLevel);
public class PlayerLevel : LoboMonoBehaviour, IObserverListener
{

    [SerializeField] private int _level = 1;
    public int Level => _level;

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.LevelUp, this);
        ObserverManager.Instance.RegisterEvent(EventType.GetPlayerLevel, this);
        this.LoadLevel();
        this.ShowLevel();
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.LevelUp, this);
        ObserverManager.Instance.RegisterEvent(EventType.GetPlayerLevel, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.LevelUp) this.LevelUp();
        else
        {
            // GetPlayerLevelDelegate getPlayerLevel = (GetPlayerLevelDelegate)data;
            // getPlayerLevel(_level);
            Debug.Log("Player Level");
        }
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
