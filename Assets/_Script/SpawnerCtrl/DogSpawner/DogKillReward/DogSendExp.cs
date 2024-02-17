using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSendExp : BaseDogKillReward
{

    [SerializeField] private int expDefault = 10;

    public void SendExp()
    {
        int scale = this.dogKillReward.GetScale();
        int expSend = scale * this.expDefault;
        ManagerCtrl.Instance.PlayerManager.PlayerExperience.ReceiveExp(expSend);
    }

}
