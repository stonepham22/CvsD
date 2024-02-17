using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpGradeButtonOff : BaseButton
{

    [SerializeField] private ShieldUpGradePriceText _upGradePriceText;
    public ShieldUpGradePriceText UpGradePriceText => _upGradePriceText;
    
    [SerializeField] private GameObject _coin;
    public GameObject Coin => _coin;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldUpGradePriceText();
        this.LoadCoin();
    }

    void LoadShieldUpGradePriceText()
    {
        if (this._upGradePriceText != null) return;
        this._upGradePriceText = GetComponentInChildren<ShieldUpGradePriceText>();
        Debug.LogWarning(transform.name + ": LoadShieldUpGradePriceText", gameObject);
    }

    void LoadCoin()
    {
        if (this._coin != null) return;
        this._coin = GameObject.Find("ButtonOffCoin");
        Debug.LogWarning(transform.name + ": LoadCoin", gameObject);
    }

}
