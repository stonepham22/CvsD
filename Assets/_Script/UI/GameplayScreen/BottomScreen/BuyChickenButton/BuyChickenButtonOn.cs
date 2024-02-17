using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyChickenButtonOn : BaseButton
{
    [SerializeField] private ChickenPriceTextButtonOn _chickenPriceText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadChickenPriceTextButtonOn();
    }

    void LoadChickenPriceTextButtonOn()
    {
        if (this._chickenPriceText != null) return;
        this._chickenPriceText = GetComponentInChildren<ChickenPriceTextButtonOn>();
        Debug.LogWarning(transform.name + ": LoadChickenPriceTextButtonOn", gameObject);
    }
    protected override void OnClick()
    {
        base.OnClick();
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ChickenSpawner.ChickenZeroSpawnInLobby();
        int chickenPrice = this.GetChickenPrice();
        ManagerCtrl.Instance.PlayerManager.PlayerCoin.DecreaseCoin(chickenPrice);
        UICtrl.Instance.CheckAllPriceInUI();
    }

    int GetChickenPrice()
    {
        BottomScreen bottomScreen = UICtrl.Instance.GameplayScreen.BottomScreen;
        int chickenPrice = bottomScreen.BuyChickenButton.ChickenPriceText.ChickenPrice;
        return chickenPrice;
    }

    protected void OnDisable()
    {
        int chickenPrice = this.GetChickenPrice();
        BuyChickenButton buyChickenButton = UICtrl.Instance.GameplayScreen.BottomScreen.BuyChickenButton;
        buyChickenButton.ButtonOff.ChickenPriceText.ShowChickenPrice(chickenPrice);
    }

}
