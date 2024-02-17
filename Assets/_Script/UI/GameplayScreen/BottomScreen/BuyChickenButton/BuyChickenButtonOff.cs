using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyChickenButtonOff : LoboMonoBehaviour
{

    [SerializeField] private ChickenPriceTextButtonOff _chickenPriceText;
    public ChickenPriceTextButtonOff ChickenPriceText=> _chickenPriceText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadChickenPriceTextButtonOff();
    }

    void LoadChickenPriceTextButtonOff()
    {
        if (this._chickenPriceText != null) return;
        this._chickenPriceText = GetComponentInChildren<ChickenPriceTextButtonOff>();
        Debug.LogWarning(transform.name + ": LoadChickenPriceTextButtonOff", gameObject);
    }

}
