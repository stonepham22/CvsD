using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void GetPlayerCoinDelegate(int playerCoin);
public class PlayerCoin : BaseSingleton<PlayerCoin>, IObserverListener
{

    [SerializeField] private int _playerCoin = 10;
    public int Coin => _playerCoin;

    protected override void Awake()
    {
        base.Awake();
        this.GetCoinFromPlayerPrefs();
    }

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
        ObserverManager.Instance.RegisterEvent(EventType.BuyChicken, this);

        ObserverManager.Instance.RegisterEvent(EventType.ShieldRepaired, this);
        ObserverManager.Instance.RegisterEvent(EventType.ShieldUpgraded, this);
        ObserverManager.Instance.RegisterEvent(EventType.ShieldOnEnable, this);

        ObserverManager.Instance.RegisterEvent(EventType.OnClickShoppingMenuItemButton, this);
        ObserverManager.Instance.RegisterEvent(EventType.EnableShoppingMenuItemButton, this);
        this.ShowCoin();
    }

    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.DogOnDead)
        {
            DogData dogData = (DogData)data;
            int coin = dogData.coinDefault;
            this.IncreaseCoin(coin);
        }

        else if(type == EventType.ShieldOnEnable)
        {
            if(data.GetType() == typeof(ShieldPrefabRepair))
            {
                ShieldPrefabRepair shieldPrefabRepair = (ShieldPrefabRepair)data;
                shieldPrefabRepair.SetPlayerCoin(_playerCoin);
            }

            else
            {
                ShieldPrefabUpgrade shieldPrefabUpgrade = (ShieldPrefabUpgrade)data;
                shieldPrefabUpgrade.SetPlayerCoin(_playerCoin);
            }    
            
        }
        else if(type == EventType.BuyChicken)
        {
            this.DecreaseCoin((int)data);
        }

        else if(type == EventType.OnClickShoppingMenuItemButton)
        {
            this.DecreaseCoin(((ItemButtonData)data).itemPrice);
        }
        else
        {
            ItemButtonDelegateData itemButtonDelegateData = (ItemButtonDelegateData)data;
            GetPlayerCoinDelegate getPlayerCoinDelegate = itemButtonDelegateData.getPlayerCoinDelegate;
            getPlayerCoinDelegate(this._playerCoin);      
        }
        
    }

    public void IncreaseCoin(int coin)
    {
        this._playerCoin += coin;
        this.ShowCoin();
        this.SaveCoin();
        ObserverManager.Instance.NotifyEvent(EventType.IncreaseCoin, _playerCoin);
    }

    public void DecreaseCoin(int coin)
    {
        this._playerCoin -= coin;
        this.ShowCoin();
        this.SaveCoin();
        ObserverManager.Instance.NotifyEvent(EventType.DecreaseCoin, _playerCoin);
    }

    private void ShowCoin()
    {
        ObserverManager.Instance.NotifyEvent(EventType.ShowCoin, this._playerCoin);
    }

    private void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", this._playerCoin);
    }    

    private void GetCoinFromPlayerPrefs()
    {
        PlayerPrefs.GetInt("Coin", this._playerCoin);
    }

    
}
