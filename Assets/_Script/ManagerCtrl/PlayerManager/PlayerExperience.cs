using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : BasePlayerManager
{

    private int _totalExp = 100; 
    private int _expToNextLevel = 0;
    [SerializeField] private int _xp = 0;

    private void Start()
    {
        this.ShowExpSlider();
    }

    private void FixedUpdate()
    {
        this.CheckExp();
    }

    void CheckExp()
    {
        if (this._xp < this._totalExp) return;
        this.CalExpNextLevel();
        this.playerManager.PlayerLevel.LevelUp();
    }

    public void CalExpNextLevel()
    {
        this._expToNextLevel = (int)(this._expToNextLevel + this._totalExp * 1.5);
        this._totalExp = this._expToNextLevel + this._totalExp;
    }

    public void ReceiveExp(int expPoint)
    {
        this._xp += expPoint;
        this.ShowExpSlider();
    }

    void ShowExpSlider()
    {
        float value = (float)this._xp / (float)this._totalExp;
        UICtrl.Instance.GameplayScreen.TopScreen.LevelExp.ShowExpSlider(value);
    }   

}
