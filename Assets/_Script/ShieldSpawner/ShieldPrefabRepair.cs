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
        this.RegisterEvent();
    }
    private void OnDisable()
    {
        this.UnregisterEvent();
    }

    private void RegisterEvent()
    {
        List<EventType> types = new List<EventType>
        {
            EventType.IncreaseCoin,
            EventType.DecreaseCoin,
        };
        ObserverManager.Instance.RegistEvent(types, this);
    }
    private void UnregisterEvent()
    {
        List<EventType> types = new List<EventType>
        {
            EventType.IncreaseCoin,
            EventType.DecreaseCoin,
        };
        ObserverManager.Instance?.UnregistEvent(types, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        if(data is int playerCoin)
        {
            SetPlayerCoin(playerCoin);
        }
        else
        {
            Debug.Log(type);
        }
        
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
