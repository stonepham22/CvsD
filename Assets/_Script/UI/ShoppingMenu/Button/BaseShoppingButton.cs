using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseShoppingButton : BaseButton
{

    [SerializeField] protected ShoppingMenu shoppingMenu;
    [SerializeField] protected Text text;

    [SerializeField] protected int index;
    [SerializeField] protected int level = 1;
    [SerializeField] protected int price = 1;
    [SerializeField] protected int scale = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShoppingMenu();
        this.LoadText();
    }

    void LoadShoppingMenu()
    {
        if (this.shoppingMenu != null) return;
        this.shoppingMenu = GetComponentInParent<ShoppingMenu>();
        Debug.LogWarning(transform.name + ": LoadShoppingMenu", gameObject);
    }

    void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponentInChildren<Text>();
        Debug.LogWarning(transform.name + ": LoadText", gameObject);
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

    void CheckLevel()
    {
        int levelPlayer = ManagerCtrl.Instance.PlayerManager.PlayerLevel.GetLevel();
        if (this.level < levelPlayer) return;
        transform.gameObject.SetActive(false);
        this.OnEnableButtonMax();
    }

    public void CheckPrice()
    {
        int playerCoin = ManagerCtrl.Instance.PlayerManager.PlayerCoin.GetCoin();
        if (this.price < playerCoin) return;
        transform.gameObject.SetActive(false);
        this.OnEnableButtonOff();
        this.ShowPrice();
    }
    
    void OnEnableButtonOff()
    {
        UICtrl.Instance.OnEnableButtonOff(this.index);
    }    

    void OnEnableButtonMax()
    {
        this.shoppingMenu.ItemBuyList.OnEnableButtonMax(this.index);
    }

    void ShowPrice()
    {
        this.shoppingMenu.Price.ShowText(this.index, this.price);
    }    

}
