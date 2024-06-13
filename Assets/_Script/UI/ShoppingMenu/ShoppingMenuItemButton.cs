using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingMenuItemButton : BaseButton
{
    [Header("Shopping Menu Item Button")]

    [SerializeField] private int _itemLevel = 1;
    [SerializeField] private int _itemPrice = 1;
    [SerializeField] private int _itemScalePrice = 1;
    [SerializeField] private int _playerLevel;

    private void GetPlayerLevel(int playerLevel)
    {
        this._playerLevel = playerLevel;
    }

    private void OnEnable()
    {
        ObserverManager.Instance.NotifyEvent
        (EventType.EnableShoppingMenuItemButton, new GetPlayerLevelDelegate(GetPlayerLevel));
    }
    
    protected override void OnClick()
    {
        base.OnClick();
        this._itemLevel++;
        this._itemPrice += this._itemScalePrice;
        ItemButtonData itemButtonData = new ItemButtonData
        {
            itemPrefab = transform.parent.gameObject,
            itemPrice = this._itemPrice,
            itemLevel = this._itemLevel
        };
        ObserverManager.Instance.NotifyEvent(EventType.OnClickShoppingMenuItemButton, itemButtonData);
        // this.CheckLevel();
    }    
}
