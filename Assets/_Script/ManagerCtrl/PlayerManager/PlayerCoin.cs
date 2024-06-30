using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void GetPlayerCoinDelegate(int playerCoin);
public class PlayerCoin : BaseSingleton<PlayerCoin>, IObserverListener
{
    [SerializeField] private int _playerCoin = 10;
    public int Coin => _playerCoin;

    private void Start()
    {
        this.RegisteredEvents();
        this.ShowCoin();
    }

    private void RegisteredEvents()
    {
        List<EventType> types = new List<EventType>
        {
            EventType.DogOnDead,
            EventType.BuyChicken,
            EventType.ShieldRepaired,
            EventType.ShieldUpgraded,
            EventType.ShieldOnEnable,
            EventType.OnClickShoppingMenuItemButton,
            EventType.EnableShoppingMenuItemButton
        };
        ObserverManager.Instance.RegistEvent(types, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        switch (type)
        {
            case EventType.DogOnDead:
                HandleDogOnDead(data);
                break;
            
            case EventType.ShieldOnEnable:
                HandShieldOnEnable(data);
                break;

            case EventType.BuyChicken:
                HandleBuyChicken(data);
                break;

            case EventType.OnClickShoppingMenuItemButton:
                HandleOnClickShoppingMenuItemButton(data);
                break;

            case EventType.EnableShoppingMenuItemButton:
                HandleEnableShoppingMenuItemButton(data);
                break;
        }

    }
    private void HandleDogOnDead(object data)
    {
        if(data is DogData dogData)
        {
            int coin = dogData.coinDefault;
            IncreaseCoin(coin);
        }
    }
    private void HandShieldOnEnable(object data)
    {
        if(data is ShieldPrefabRepair)
        {
            ShieldPrefabRepair shieldPrefabRepair = (ShieldPrefabRepair)data;
            shieldPrefabRepair.SetPlayerCoin(_playerCoin);
        }
        else if(data is ShieldPrefabUpgrade)
        {
            ShieldPrefabUpgrade shieldPrefabUpgrade = (ShieldPrefabUpgrade)data;
            shieldPrefabUpgrade.SetPlayerCoin(_playerCoin);
        }
    }
    private void HandleBuyChicken(object data)
    {
        if(data is int)
        {
            int coin = (int)data;
            DecreaseCoin(coin);
        }
    }
    private void HandleOnClickShoppingMenuItemButton(object data)
    {
        if(data is ItemButtonData)
        {
            ItemButtonData itemButtonData = (ItemButtonData)data;
            DecreaseCoin(itemButtonData.itemPricePrev);
        }
    }
    private void HandleEnableShoppingMenuItemButton(object data)
    {
        if(data is ItemButtonData)
        {
            ItemButtonData itemButtonData = (ItemButtonData)data;
            GetPlayerCoinDelegate getPlayerCoinDelegate = itemButtonData.getPlayerCoinDelegate;
            getPlayerCoinDelegate(_playerCoin);
        }
    }

    public void IncreaseCoin(int coin)
    {
        this._playerCoin += coin;
        this.ShowCoin();
        ObserverManager.Instance.NotifyEvent(EventType.IncreaseCoin, _playerCoin);
    }
    public void DecreaseCoin(int coin)
    {
        this._playerCoin -= coin;
        this.ShowCoin();
        ObserverManager.Instance.NotifyEvent(EventType.DecreaseCoin, _playerCoin);
    }
    private void ShowCoin()
    {
        ObserverManager.Instance.NotifyEvent(EventType.ShowCoin, this._playerCoin);
    }

}
