using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRepair : LoboMonoBehaviour
{

    [SerializeField] private ShieldRepairButtonOn _buttonOn;
    public ShieldRepairButtonOn ButtonOn => _buttonOn;

    [SerializeField] private ShieldRepairButtonOff _buttonOff;
    public ShieldRepairButtonOff ButtonOff => _buttonOff;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldRepairButtonOn();
        this.LoadShieldRepairButtonOff();
    }

    void LoadShieldRepairButtonOn()
    {
        if (this._buttonOn != null) return;
        this._buttonOn = GetComponentInChildren<ShieldRepairButtonOn>();
        Debug.LogWarning(transform.name + ": LoadShieldRepairButtonOn", gameObject);
    }

    void LoadShieldRepairButtonOff()
    {
        if (this._buttonOff != null) return;
        this._buttonOff = GetComponentInChildren<ShieldRepairButtonOff>();
        Debug.LogWarning(transform.name + ": LoadShieldRepairButtonOff", gameObject);
    }


}
