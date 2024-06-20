using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingMenuItemButton : BaseButton, IObserverListener
{
    [Header("Item")]
    [SerializeField] private int _itemLevel = 1;
    [SerializeField] private int _itemPrice = 1;
    [SerializeField] private int _itemScalePrice = 1;
    [SerializeField] private int _indexItem;
    [Header("Player")]
    [SerializeField] private int _playerLevel;
    [SerializeField] private int _playerCoin;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadIndexItem();
    }

    private void OnEnable()
    {
        this.NotifyEventEnable();
    }

    protected override void Start()
    {
        base.Start();
        this.RegisterEvent();
    }

    private void RegisterEvent()
    {
        ObserverManager.Instance.RegisterEvent(EventType.ShowLevel, this);
        ObserverManager.Instance.RegisterEvent(EventType.IncreaseCoin, this);
        ObserverManager.Instance.RegisterEvent(EventType.DecreaseCoin, this);
    }
    
    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.ShowLevel) this._playerLevel = (int)data;
        else
        {
            this._playerCoin = (int)data;
            this.CheckCoin();
        }
    }
    private void NotifyEventEnable()
    {
        ItemButtonData itemButtonData = new ItemButtonData
        {
            getPlayerLevelDelegate = GetPlayerLevel,
            getPlayerCoinDelegate = GetPlayerCoin,
            itemPriceCur = this._itemPrice
        };
        ObserverManager.Instance.NotifyEvent
        (EventType.EnableShoppingMenuItemButton, itemButtonData);
    }
    protected override void OnClick()
    {
        this._itemLevel++;
        this._itemPrice += this._itemScalePrice;
        this.NotifyEventOnClick();
        this.CheckLevel();
        this.CheckCoin();
    }
    private void NotifyEventOnClick()
    {
        ItemButtonData itemButtonData = new ItemButtonData
        {
            itemPrefab = transform.parent.gameObject,
            itemPricePrev = this._itemPrice - this._itemScalePrice,
            itemPriceCur = this._itemPrice,
            itemLevel = this._itemLevel
        };
        ObserverManager.Instance.NotifyEvent
        (EventType.OnClickShoppingMenuItemButton, itemButtonData);
    }
    
    private void GetPlayerLevel(int playerLevel)
    {
        this._playerLevel = playerLevel;
    }
    private void GetPlayerCoin(int playerCoin)
    {
        this._playerCoin = playerCoin;
    }
    private void CheckLevel()
    {
        if (this._itemLevel <= this._playerLevel) return;
        ObserverManager.Instance.NotifyEvent(EventType.ItemLevelGatherThanPlayerLevel, this);
        transform.gameObject.SetActive(false);
    }
    private void CheckCoin()
    {
        if(this._itemPrice <= this._playerCoin) return;
        ObserverManager.Instance.NotifyEvent(EventType.ItemCoinGatherThanPlayerCoin, this);
        transform.gameObject.SetActive(false);        
    }

    private void LoadIndexItem()
    {
        string prefabName = transform.parent.gameObject.name;
        char index = prefabName[prefabName.Length - 1];
        _indexItem = (int)char.GetNumericValue(index);
    }
}
