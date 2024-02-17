using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingMenu : LoboMonoBehaviour
{

    [SerializeField] private ItemBuyList _itemBuyList;
    public ItemBuyList ItemBuyList => _itemBuyList;

    [SerializeField] private ButtonOn _buttonOn;
    public ButtonOn ButtonOn => _buttonOn;

    [SerializeField] private Price _price;
    public Price Price => _price;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemBuyList();
        this.LoadButtonOn();
        this.LoadPrice();
    }

    void LoadItemBuyList()
    {
        if (this._itemBuyList != null) return;
        this._itemBuyList = GetComponentInChildren<ItemBuyList>();
        Debug.LogWarning(transform.name + ": LoadItemBuyList", gameObject);
    }

    void LoadButtonOn()
    {
        if (this._buttonOn != null) return;
        this._buttonOn = GetComponentInChildren<ButtonOn>();
        Debug.LogWarning(transform.name + ": LoadButtonOn", gameObject);
    }

    void LoadPrice()
    {
        if (this._price != null) return;
        this._price = GetComponentInChildren<Price>();
        Debug.LogWarning(transform.name + ": LoadPrice", gameObject);
    }

    public void CheckPriceAll()
    {
        this._buttonOn.CheckPriceAll();
    }   

}
