using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseShoppingButton : BaseButton, IObserverListener
{

    [SerializeField] protected ShoppingMenu shoppingMenu;
    // [SerializeField] protected Text text;
    [SerializeField] protected int index;
    [SerializeField] protected int itemLevel = 1;
    [SerializeField] protected int price = 1;
    [SerializeField] protected int scale = 1;
    [SerializeField] protected int levelPlayer;

    [SerializeField] protected ShoppingMenuItemLevel itemLevelShoppingMenu;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShoppingMenu();
        // this.LoadText();
        this.LoadItemLevelShoppingMenu();
    }

    protected override void Start()
    {
        base.Start();
        ObserverManager.Instance.RegisterEvent(EventType.ShowLevel, this);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.ShowLevel, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        int level = (int)data;
        this.levelPlayer = level;
    }

    public void CheckPrice()
    {
        int playerCoin = PlayerCoin.Instance.Coin;
        if (this.price < playerCoin) return;
        transform.gameObject.SetActive(false);
        this.OnEnableButtonOff();
        this.ShowPrice();
    }

    protected override void OnClick()
    {
        base.OnClick();
        this.itemLevel++;
        this.price += this.scale;
        ObserverManager.Instance.NotifyEvent(EventType.OnClickShoppingButton, this.price);
        // UICtrl.Instance.ShoppingMenu.ItemBuyList.ShowLevel(this.index, this.level);
        this.CheckLevel();
    }

    private void LoadShoppingMenu()
    {
        if (this.shoppingMenu != null) return;
        this.shoppingMenu = GetComponentInParent<ShoppingMenu>();
        Debug.LogWarning(transform.name + ": LoadShoppingMenu", gameObject);
    }

    private void LoadItemLevelShoppingMenu()
    {
        if (this.itemLevelShoppingMenu != null) return;
        this.itemLevelShoppingMenu = transform.parent.GetComponentInChildren<ShoppingMenuItemLevel>();
        Debug.LogWarning(transform.name + ": LoadShoppingMenu", gameObject);
    }

    // private void LoadText()
    // {
    //     if (this.text != null) return;
    //     this.text = GetComponentInChildren<Text>();
    //     Debug.LogWarning(transform.name + ": LoadText", gameObject);
    // }

    private void CheckLevel()
    {
        if (this.itemLevel < this.levelPlayer) return;
        transform.gameObject.SetActive(false);
        this.OnEnableButtonMax();
    }

    private void OnEnableButtonOff()
    {
        UICtrl.Instance.OnEnableButtonOff(this.index);
    }    

    private void OnEnableButtonMax()
    {
        this.shoppingMenu.ItemBuyList.OnEnableButtonMax(this.index);
    }

    private void ShowPrice()
    {
        this.shoppingMenu.Price.ShowText(this.index, this.price);
    }

   
}
