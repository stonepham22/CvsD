using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseShoppingButton : BaseButton, IObserverListener
{

    [SerializeField] protected ShoppingMenu shoppingMenu;
    [SerializeField] protected Text text;

    [SerializeField] protected int index;
    [SerializeField] protected int level = 1;
    [SerializeField] protected int price = 1;
    [SerializeField] protected int scale = 1;

    [SerializeField] protected int levelPlayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShoppingMenu();
        this.LoadText();
    }

    protected override void Start()
    {
        base.Start();
        this.RegisterEventShowLevel();
    }

    public void NotifyEvent(object data)
    {
        int level = (int)data;
        this.levelPlayer = level;
    }

    public void CheckPrice()
    {
        int playerCoin = ManagerCtrl.Instance.PlayerManager.PlayerCoin.GetCoin();
        if (this.price < playerCoin) return;
        transform.gameObject.SetActive(false);
        this.OnEnableButtonOff();
        this.ShowPrice();
    }

    protected override void OnClick()
    {
        base.OnClick();
        this.level++;
        this.price += this.scale;
        ManagerCtrl.Instance.PlayerManager.PlayerCoin.DecreaseCoin(this.price);
        UICtrl.Instance.ShoppingMenu.ItemBuyList.ShowLevel(this.index, this.level);
        this.CheckLevel();
    }

    private void RegisterEventShowLevel()
    {
        ObserverManager.Instance.RegisterEvent(EventType.ShowLevel, this);
    }

    private void LoadShoppingMenu()
    {
        if (this.shoppingMenu != null) return;
        this.shoppingMenu = GetComponentInParent<ShoppingMenu>();
        Debug.LogWarning(transform.name + ": LoadShoppingMenu", gameObject);
    }

    private void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponentInChildren<Text>();
        Debug.LogWarning(transform.name + ": LoadText", gameObject);
    }

    private void CheckLevel()
    {
        if (this.level < this.levelPlayer) return;
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
