using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingMenuItemButton : BaseButton
{
    [Header("Shopping Menu Item Button")]

    [SerializeField] private int _itemLevel;
    [SerializeField] private int _itemPrice;
    [SerializeField] private int _itemScalePrice;
    [SerializeField] private int _playerLevel;

    

    private void GetPlayerLevel(int playerLevel)
    {
        this._playerLevel = playerLevel;
    }


    private void OnEnable()
    {
        // GetPlayerLevelDelegate getPlayerLevelDelegate = new GetPlayerLevelDelegate(GetPlayerLevel);
        // if(getPlayerLevelDelegate == null) Debug.Log("ShoppingMenuItemButton");
        ObserverManager.Instance.NotifyEvent(EventType.GetPlayerLevel, this);
    }
    
    protected override void OnClick()
    {
        base.OnClick();
        this._itemLevel++;
        this._itemPrice += this._itemScalePrice;
        ObserverManager.Instance.NotifyEvent(EventType.OnClickShoppingButton, this._itemPrice);
        // show level
        // this.CheckLevel();
    }    
}
