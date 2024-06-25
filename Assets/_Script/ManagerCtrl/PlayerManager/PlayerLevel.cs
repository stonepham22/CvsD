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
        this.RegisterEvent();
    }
    private void Start()
    {
        this.ShowLevel();
    }

    private void RegisterEvent()
    {
        List<EventType> types = new List<EventType>
        {
            EventType.LevelUp,
            EventType.EnableShoppingMenuItemButton
        };
        ObserverManager.Instance.RegisterEvent(types, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        switch (type)
        {
            case EventType.LevelUp:
                HandleLevelUp();
                break;
            case EventType.EnableShoppingMenuItemButton:
                HandleEnableShoppingMenuItemButton(data);
                break;
        }
    }
    private void HandleLevelUp()
    {
        this._playerLevel++;
        this.ShowLevel();
    }
    private void HandleEnableShoppingMenuItemButton(object data)
    {
        if(data is ItemButtonData itemButtonData)
        {
            GetPlayerLevelDelegate getPlayerLevelDelegate = itemButtonData.getPlayerLevelDelegate;
            getPlayerLevelDelegate(_playerLevel);
        }
    }

    private void ShowLevel()
    {
        ObserverManager.Instance.NotifyEvent(EventType.ShowLevel, this._playerLevel);
    }    
}
