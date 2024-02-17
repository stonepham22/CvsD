using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKillReward : BaseDogPrefab
{

    [SerializeField] private DogSendExp _dogSendExp;
    [SerializeField] private DogSendCoin _dogSendCoin;
    [SerializeField] private int _scale;
    
    protected override void LoadComponents() 
    {
        base.LoadComponents();
        this.LoadDogSendExp();
        this.LoadDogSendCoin();
        this.LoadScale();
    }

    void LoadDogSendExp()
    {
        if (this._dogSendExp != null) return;
        this._dogSendExp = GetComponentInChildren<DogSendExp>();
        Debug.LogWarning(transform.name + ": LoadDogSendExp", gameObject);
    }

    void LoadDogSendCoin()
    {
        if (this._dogSendCoin != null) return;
        this._dogSendCoin = GetComponentInChildren<DogSendCoin>();
        Debug.LogWarning(transform.name + ": LoadDogSendCoin", gameObject);
    }

    void LoadScale()
    {
        string DogPrefabName = this.dogPrefabCtrl.gameObject.name;
        char dogPrefabIndex = DogPrefabName[DogPrefabName.Length - 1];
        this._scale = (int)Char.GetNumericValue(dogPrefabIndex);
    }

    public void SendReward()
    {
        this._dogSendExp.SendExp();
        this._dogSendCoin.SendCoin();
    }    

    public int GetScale()
    {
        return this._scale;
    }

}
