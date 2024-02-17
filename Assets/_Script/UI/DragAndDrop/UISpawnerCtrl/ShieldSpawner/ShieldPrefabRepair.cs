using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPrefabRepair : BaseShieldPrefab
{
    [SerializeField] private int _repairPrice = 1;
    [SerializeField] private int _scaleRepairPrice = 1;

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

    public void ShieldPrefabRepaired()
    {
        if (!this.IsCanRepair()) return;
        this.shieldPrefab.DamageReceiver.ShieldPrefabRepaired();
        ManagerCtrl.Instance.PlayerManager.PlayerCoin.DecreaseCoin(this._repairPrice);
        this._repairPrice += this._scaleRepairPrice;
        this._scaleRepairPrice++;
        this.ShieldPrefabRepairing();
    }

    private bool IsEnoughMoney()
    {
        int playerCoin = ManagerCtrl.Instance.PlayerManager.PlayerCoin.Coin;
        if (playerCoin < this._repairPrice) return false;
        return true;
    }
    
}
