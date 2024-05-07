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
        this.ShowCoin();
        ObserverManager.Instance.RegisterEvent(EventType.IncreaseCoin, this);
    }

    public void NotifyEvent(object data)
    {
        int coin = (int)data;
        this.IncreaseCoin(coin);
    }

    public int GetCoin()
    {
        return this._coin;
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
