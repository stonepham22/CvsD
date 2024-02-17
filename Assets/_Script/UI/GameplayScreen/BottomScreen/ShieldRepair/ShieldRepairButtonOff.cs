using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRepairButtonOff : BaseButton
{

    [SerializeField] private ShieldSlider _shieldSlider;
    public ShieldSlider ShieldSlider => _shieldSlider;

    [SerializeField] private RepairPriceText _repairPriceText;
    public RepairPriceText RepairPriceText => _repairPriceText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldSlider();
        this.LoadRepairPriceText();
    }

    void LoadShieldSlider()
    {
        if (this._shieldSlider != null) return;
        this._shieldSlider = GetComponentInChildren<ShieldSlider>();
        Debug.LogWarning(transform.name + ": LoadShieldSlider", gameObject);
    }

    void LoadRepairPriceText()
    {
        if (this._repairPriceText != null) return;
        this._repairPriceText = GetComponentInChildren<RepairPriceText>();
        Debug.LogWarning(transform.name + ": LoadRepairPriceText", gameObject);
    }

}
