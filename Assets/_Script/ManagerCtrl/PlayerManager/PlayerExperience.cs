using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : LoboMonoBehaviour, IObserverListener
{
    [Header("Player Experience")]
    [SerializeField] private int _totalExp = 100;
    [SerializeField] private int _xp = 0;
    [SerializeField] private float _scale = 1.5f;

    private void Start()
    {
        this.ShowExpSlider();
        this.RegisterEvent();
    }

    private void RegisterEvent()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        if(data is DogData dogData)
        {
            int exp = dogData.expDefault;
            this.ReceiveExp(exp);
        }
    }

    private void CheckExp()
    {
        if (this._xp < this._totalExp) return;
        this.CalculateExpNextLevel();
        float value = (float)this._xp / (float)this._totalExp;
        ObserverManager.Instance.NotifyEvent(EventType.LevelUp, value);
    }

    private void CalculateExpNextLevel()
    {
        this._totalExp += (int)(this._totalExp * this._scale);
    }

    private void ReceiveExp(int expPoint)
    {
        this._xp += expPoint;
        this.CheckExp();
        this.ShowExpSlider();
    }

    private void ShowExpSlider()
    {
        float value = (float)this._xp / (float)this._totalExp;
        ObserverManager.Instance.NotifyEvent(EventType.ShowExp, value);
    }
}
