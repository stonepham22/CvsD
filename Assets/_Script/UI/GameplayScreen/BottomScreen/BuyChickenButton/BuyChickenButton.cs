using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BuyChickenButton : LoboMonoBehaviour
{
    [Header("Components")]
    [SerializeField] private BuyChickenButtonOff _buttonOff;
    public BuyChickenButtonOff ButtonOff => _buttonOff;

    [SerializeField] private BuyChickenButtonOn _buttonOn;
    [SerializeField] private ChickenPriceTextButtonOn _chickenPriceText;
    public ChickenPriceTextButtonOn ChickenPriceText => _chickenPriceText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBuyChickenButtonOff();
        this.LoadBuyChickenButtonOn();
        this.LoadChickenPriceText();
    }

    void LoadBuyChickenButtonOff()
    {
        if (this._buttonOff != null) return;
        this._buttonOff = GetComponentInChildren<BuyChickenButtonOff>();
        Debug.LogWarning(transform.name + ": LoadBuyChickenButtonOff", gameObject);
    }

    void LoadBuyChickenButtonOn()
    {
        if (this._buttonOn != null) return;
        this._buttonOn = GetComponentInChildren<BuyChickenButtonOn>();
        Debug.LogWarning(transform.name + ": LoadBuyChickenButtonOn", gameObject);
    }

    void LoadChickenPriceText()
    {
        if (this._chickenPriceText != null) return;
        this._chickenPriceText = GetComponentInChildren<ChickenPriceTextButtonOn>();
        Debug.LogWarning(transform.name + ": LoadChickenPriceText", gameObject);
    }

    void ShowChickenPriceText()
    {
        this._chickenPriceText.ShowChickenPriceText();
    }    

}
