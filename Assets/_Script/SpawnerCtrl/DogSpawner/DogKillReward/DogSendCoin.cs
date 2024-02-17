using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSendCoin : BaseDogKillReward
{
    [Header("DogSendCoin")]

    [SerializeField] private int _coinDefault = 1;    
    
    public void SendCoin()
    {
        int scale = this.dogKillReward.GetScale();
        int coin = scale * this._coinDefault;
        ManagerCtrl.Instance.PlayerManager.PlayerCoin.IncreaseCoin(coin);
    }    

}
