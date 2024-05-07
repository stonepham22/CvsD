using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : BasePlayerManager, IObserverListener
{

    private int _totalExp = 100; 
    private int _expToNextLevel = 0;
    [SerializeField] private int _xp = 0;

    private void Start()
    {
        this.ShowExpSlider();
        this.RegisterEventDogSendExpToPlayer();
    }

    public void NotifyEvent(object data)
    {
        int exp = (int)data;
        this.ReceiveExp(exp);
    }

    private void RegisterEventDogSendExpToPlayer()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogSendExpToPlayer, this);
    }

    private void FixedUpdate()
    {
        this.CheckExp();
    }

    private void CheckExp()
    {
        if (this._xp < this._totalExp) return;
        this.CalculateExpNextLevel();

        ObserverManager.Instance.NotifyEvent(EventType.LevelUp, null);
        
        this.ShowExpSlider();
    }

    private void CalculateExpNextLevel()
    {
        this._expToNextLevel = (int)(this._expToNextLevel + this._totalExp * 1.5);
        this._totalExp = this._expToNextLevel + this._totalExp;
    }

    private void ReceiveExp(int expPoint)
    {
        this._xp += expPoint;
        this.ShowExpSlider();
    }

    private void ShowExpSlider()
    {
        float value = (float)this._xp / (float)this._totalExp;
        ObserverManager.Instance.NotifyEvent(EventType.ShowExp, value);
    }

    
}
