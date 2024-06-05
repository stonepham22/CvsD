using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoin : MonoBehaviour, IObserverListener
{

    [SerializeField] private int _coin = 10;
    public int Coin => _coin;

    private void Awake()
    {
        this.GetCoinFromPlayerPrefs();
    }

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
        ObserverManager.Instance.RegisterEvent(EventType.BuyChicken, this);
        ObserverManager.Instance.RegisterEvent(EventType.ShieldRepaired, this);
        this.ShowCoin();
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.DogOnDead, this);
        ObserverManager.Instance.UnregisterEvent(EventType.BuyChicken, this);
        ObserverManager.Instance.RegisterEvent(EventType.ShieldRepaired, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.DogOnDead)
        {
            DogData dogData = (DogData)data;
            int coin = dogData.coinDefault;
            this.IncreaseCoin(coin);
        }

        else if(type == EventType.BuyChicken || type == EventType.ShieldRepaired)
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
