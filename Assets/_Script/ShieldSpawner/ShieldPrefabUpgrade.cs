using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPrefabUpgrade : BaseShieldPrefab, IObserverListener
{
    [SerializeField] private int _upgradePrice = 1;
    [SerializeField] private int _scaleUpgradePrice = 1;
    [SerializeField] private int _playerCoin;

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterEvent(EventType.IncreaseCoin, this);
        ObserverManager.Instance.RegisterEvent(EventType.DecreaseCoin, this);

        ObserverManager.Instance.NotifyEvent(EventType.ShieldOnEnable, this);
    }

    private void OnDisable()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.IncreaseCoin, this);
        ObserverManager.Instance.UnregisterEvent(EventType.DecreaseCoin, this);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.IncreaseCoin, this);
        ObserverManager.Instance.UnregisterEvent(EventType.DecreaseCoin, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        SetPlayerCoin((int)data);
    }

    public void SetPlayerCoin(int playerCoin)
    {
        this._playerCoin = playerCoin;
    }

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

    public void ShieldUpgraded()
    {
        this.shieldPrefab.DamageReceiver.UpgradeHp();
        ObserverManager.Instance.NotifyEvent(EventType.ShieldUpgraded, _upgradePrice);
        this._upgradePrice += this._scaleUpgradePrice;
        this._scaleUpgradePrice += 1;
        this.ShowUpgradePrice();
        this.ShieldPrefabUpgrading();
    }

    bool CheckEnoughMoney()
    {
        if(_playerCoin < this._upgradePrice) return false;
        return true;
    }    

    void ShowUpgradePrice()
    {
        UICtrl.Instance.GameplayScreen.BottomScreen.ShieldUpgrade.ButtonOn.UpGradePriceText.ShowUpGradePrice(this._upgradePrice);
    }
   
}
