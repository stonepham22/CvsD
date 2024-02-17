using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrade : LoboMonoBehaviour
{

    [SerializeField] private ShieldUpGradeButtonOn _buttonOn;
    public ShieldUpGradeButtonOn ButtonOn => _buttonOn;

    [SerializeField] private ShieldUpGradeButtonOff _buttonOff;
    public ShieldUpGradeButtonOff ButtonOff => _buttonOff;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldUpGradeButtonOn();
        this.LoadShieldUpGradeButtonOff();
    }

    void LoadShieldUpGradeButtonOn()
    {
        if (this._buttonOn != null) return;
        this._buttonOn = GetComponentInChildren<ShieldUpGradeButtonOn>();
        Debug.LogWarning(transform.name + ": LoadShieldUpGradeButtonOn", gameObject);
    }

    void LoadShieldUpGradeButtonOff()
    {
        if (this._buttonOff != null) return;
        this._buttonOff = GetComponentInChildren<ShieldUpGradeButtonOff>();
        Debug.LogWarning(transform.name + ": LoadShieldUpGradeButtonOff", gameObject);
    }

}
