using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonOn : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        UICtrl.Instance.ShoppingMenu.gameObject.SetActive(true);
        UICtrl.Instance.GameplayScreen.gameObject.SetActive(false);
    }
}
