using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPrefabRepair : BaseShieldPrefab, IObserverListener
{
    [SerializeField] private int _repairPrice = 1;
    [SerializeField] private int _scaleRepairPrice = 1;
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

    public void NotifyEvent(EventType type, object data)
    {
        SetPlayerCoin((int)data);
    }

    public void SetPlayerCoin(int playerCoin)
    {
        this._playerCoin = playerCoin;
    }

    public void ShieldPrefabRepaired()
    {
        if (!this.IsCanRepair()) return;
        this.shieldPrefab.DamageReceiver.ShieldPrefabRepaired();
        ObserverManager.Instance.NotifyEvent(EventType.ShieldRepaired, _repairPrice);
        this._repairPrice += this._scaleRepairPrice;
        this._scaleRepairPrice++;
        this.ShieldPrefabRepairing();
    }

    public void ShieldPrefabRepairing()
    {
        if (this.IsCanRepair()) this.CanRepair();
        else this.CantRepair();
    }

    private bool IsCanRepair()
    {
        if (!this.shieldPrefab.DamageReceiver.IsCanRepair()) return false;
        if(!this.IsEnoughMoney()) return false;
        return true;
    }

    private void CanRepair()
    {
        UICtrl.Instance.GameplayScreen.BottomScreen.ShieldRepair.ButtonOff.gameObject.SetActive(false);
        this.shieldPrefab.DamageReceiver.ShowShieldSliderButtonOn();
        this.ShowRepairPriceButtonOn();
    }

    private void CantRepair()
    {
        UICtrl.Instance.GameplayScreen.BottomScreen.ShieldRepair.ButtonOff.gameObject.SetActive(true);
        this.shieldPrefab.DamageReceiver.ShowShieldSliderButtonOff();
        this.ShowRepairPriceButtonOff();
    }

    private void ShowRepairPriceButtonOn()
    {
        UICtrl.Instance.GameplayScreen.BottomScreen.ShieldRepair.ButtonOn.RepairPriceText.ShowRepairPrice(this._repairPrice);
    }

    private void ShowRepairPriceButtonOff()
    {
        UICtrl.Instance.GameplayScreen.BottomScreen.ShieldRepair.ButtonOff.RepairPriceText.ShowRepairPrice(this._repairPrice);
    }

    private bool IsEnoughMoney()
    {
        if (_playerCoin < this._repairPrice) return false;
        return true;
    }

    
}
