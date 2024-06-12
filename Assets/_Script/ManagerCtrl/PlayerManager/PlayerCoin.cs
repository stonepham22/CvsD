using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoin : BaseSingleton<PlayerCoin>, IObserverListener
{

    [SerializeField] private int _coin = 10;
    public int Coin => _coin;

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

        ObserverManager.Instance.RegisterEvent(EventType.OnClickShoppingButton, this);
        this.ShowCoin();
    }

    protected override void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.DogOnDead, this);
        ObserverManager.Instance.UnregisterEvent(EventType.BuyChicken, this);

        ObserverManager.Instance.UnregisterEvent(EventType.ShieldRepaired, this);
        ObserverManager.Instance.UnregisterEvent(EventType.ShieldUpgraded, this);
        ObserverManager.Instance.UnregisterEvent(EventType.ShieldOnEnable, this);

        ObserverManager.Instance.UnregisterEvent(EventType.OnClickShoppingButton, this);
        base.OnDestroy();
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
                shieldPrefabRepair.SetPlayerCoin(_coin);
            }

            else
            {
                ShieldPrefabUpgrade shieldPrefabUpgrade = (ShieldPrefabUpgrade)data;
                shieldPrefabUpgrade.SetPlayerCoin(_coin);
            }    
            
        }

        else
        {
            int coin = (int)data;
            this.DecreaseCoin(coin);
        }
        
    }

    public void IncreaseCoin(int coin)
    {
        this._coin += coin;
        this.ShowCoin();
        this.SaveCoin();
        ObserverManager.Instance.NotifyEvent(EventType.IncreaseCoin, _coin);
    }

    public void DecreaseCoin(int coin)
    {
        this._coin -= coin;
        this.ShowCoin();
        this.SaveCoin();
        ObserverManager.Instance.NotifyEvent(EventType.DecreaseCoin, _coin);
    }

    private void ShowCoin()
    {
        ObserverManager.Instance.NotifyEvent(EventType.ShowCoin, this._coin);
    }

    private void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", this._coin);
    }    

    private void GetCoinFromPlayerPrefs()
    {
        PlayerPrefs.GetInt("Coin", this._coin);
    }

    
}
