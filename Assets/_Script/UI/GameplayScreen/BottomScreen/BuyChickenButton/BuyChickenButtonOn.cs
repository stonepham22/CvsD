using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyChickenButtonOn : BaseButton, IObserverListener
{
    [Header("Buy Chicken Button On")]
    [SerializeField] private int _chickenPrice = 1;

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DecreaseCoin, this);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.DecreaseCoin, this);
    }

    protected override void OnClick()
    {
        base.OnClick();
        ObserverManager.Instance.NotifyEvent(EventType.BuyChicken, _chickenPrice);
    }

    public void NotifyEvent(EventType type, object data)
    {
        int playerCoin = (int)data;
        CheckChickPrice(playerCoin);
    }

    private void CheckChickPrice(int playerCoin)
    {
        if (_chickenPrice <= playerCoin) return;
        transform.gameObject.SetActive(false);
        ObserverManager.Instance.NotifyEvent(EventType.DisableChickenButtonOn, _chickenPrice);
    }

}
