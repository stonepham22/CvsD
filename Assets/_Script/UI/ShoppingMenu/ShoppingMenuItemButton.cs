using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingMenuItemButton : BaseButton, IObserverListener
{
    [Header("Shopping Menu Item Button")]

    [SerializeField] private int _itemLevel = 1;
    [SerializeField] private int _itemPrice = 1;
    [SerializeField] private int _itemScalePrice = 1;
    [SerializeField] private int _playerLevel;
    [SerializeField] private int _playerCoin;

    public void NotifyEvent(EventType type, object data)
    {
        this._playerLevel = (int)data;
    }
    private void GetPlayerLevel(int playerLevel)
    {
        this._playerLevel = playerLevel;
    }

    private void GetPlayerCoin(int playerCoin)
    {
        this._playerCoin = playerCoin;
    }

    private void OnEnable()
    {
        ItemButtonDelegateData itemButtonDelegateData = new ItemButtonDelegateData
        {
            getPlayerLevelDelegate = GetPlayerLevel,
            getPlayerCoinDelegate = GetPlayerCoin
        };
        ObserverManager.Instance.NotifyEvent
        (EventType.EnableShoppingMenuItemButton, itemButtonDelegateData);

        ObserverManager.Instance.RegisterEvent(EventType.ShowLevel, this);
    }

    private void OnDisable()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.ShowLevel, this);        
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

    private void CheckLevel()
    {
        if (this._itemLevel < this._playerLevel) return;
        transform.gameObject.SetActive(false);
        
    }

    
}
