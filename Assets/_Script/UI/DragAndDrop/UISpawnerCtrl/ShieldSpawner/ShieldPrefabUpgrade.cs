using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPrefabUpgrade : BaseShieldPrefab
{
    [SerializeField] private int _upgradePrice = 1;
    [SerializeField] private int _scaleUpgradePrice = 1;
    
    public void ShieldPrefabUpgrading()
    {
        ShieldUpgrade shieldUpgrade = UICtrl.Instance.GameplayScreen.BottomScreen.ShieldUpgrade;
        if(this.CheckEnoughMoney())
        {
            ShieldUpGradeButtonOn buttonOn = shieldUpgrade.ButtonOn;
            ShieldUpGradeButtonOff buttonOff = shieldUpgrade.ButtonOff;
            buttonOff.gameObject.SetActive(false);
            buttonOn.UpGradePriceText.ShowUpGradePrice(this._upgradePrice);
        }
        else
        {
            ShieldUpGradeButtonOff buttonOff = shieldUpgrade.ButtonOff;
            buttonOff.gameObject.SetActive(true);
            buttonOff.Coin.SetActive(true);
            buttonOff.UpGradePriceText.ShowUpGradePrice(this._upgradePrice);
        }
    }

    bool CheckEnoughMoney()
    {
        int playCoin = ManagerCtrl.Instance.PlayerManager.PlayerCoin.Coin;
        if(playCoin < this._upgradePrice) return false;
        return true;
    }    

    public void ShieldUpgraded()
    {
        this.shieldPrefab.DamageReceiver.UpgradeHp();
        ManagerCtrl.Instance.PlayerManager.PlayerCoin.DecreaseCoin(this._upgradePrice);
        this._upgradePrice += this._scaleUpgradePrice;
        this._scaleUpgradePrice += 1;
        this.ShowUpgradePrice();
        this.ShieldPrefabUpgrading();
    }

    void ShowUpgradePrice()
    {
        UICtrl.Instance.GameplayScreen.BottomScreen.ShieldUpgrade.ButtonOn.UpGradePriceText.ShowUpGradePrice(this._upgradePrice);
    }

}
