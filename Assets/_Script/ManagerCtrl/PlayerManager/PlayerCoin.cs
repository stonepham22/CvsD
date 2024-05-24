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

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterEvent(EventType.IncreaseCoin, this);
        // sua lai su kien IncreaseCoin cho dung ten cua su kien cu the la gi
        ObserverManager.Instance.RegisterEvent(EventType.BuyChicken, this);
    }

    private void Start()
    {
        this.ShowCoin();
    }

    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.IncreaseCoin)
        {
            int coin = (int)data;
            this.IncreaseCoin(coin);
        }

        else if(type == EventType.BuyChicken)
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
