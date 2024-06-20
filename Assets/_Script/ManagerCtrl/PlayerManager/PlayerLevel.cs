using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
public delegate void GetPlayerLevelDelegate(int playerLevel);
public class PlayerLevel : LoboMonoBehaviour, IObserverListener
{
    [SerializeField] private int _playerLevel = 1;
    public int Level => _playerLevel;

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterEvent(EventType.LevelUp, this);
        ObserverManager.Instance.RegisterEvent(EventType.EnableShoppingMenuItemButton, this);
    }

    private void Start()
    {
        this.LoadLevel();
        this.ShowLevel();
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.LevelUp, this);
        ObserverManager.Instance.RegisterEvent(EventType.EnableShoppingMenuItemButton, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.LevelUp) this.LevelUp();
        else
        {
            ItemButtonData itemButtonData = (ItemButtonData)data;
            GetPlayerLevelDelegate getPlayerLevelDelegate = itemButtonData.getPlayerLevelDelegate;
            getPlayerLevelDelegate(this._playerLevel);
        }
    }

    private void LoadLevel()
    {
            
    }

    public void LevelUp()
    {
        this._playerLevel++;
        this.ShowLevel();
    }

    private void ShowLevel()
    {
        ObserverManager.Instance.NotifyEvent(EventType.ShowLevel, this._playerLevel);
    }    
}
