using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtonOn : BaseButton
{

    protected override void OnClick()
    {
        this.NotifyEventOnClick();
    }

    private void NotifyEventOnClick()
    {
        ObserverManager.Instance.NotifyEvent(EventType.OnClickShoppingButtonOn, this);
        SceneManager.LoadScene("ShoppingMenu");
    }

}
