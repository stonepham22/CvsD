using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOn : LoboMonoBehaviour
{

    [SerializeField] private DamageButton _damageButton;
    [SerializeField] private AttackButton _attackButton;
    [SerializeField] private EggLoadButton _eggLoadButton;
    [SerializeField] private MoneyButton _moneyButton;
    [SerializeField] private ChickenPriceButton _chickenPriceButton;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageButton();
        this.LoadAttackButton();
        this.LoadEggLoadButton();
        this.LoadMoneyButton();
        this.LoadChickenPriceButton();
    }

    void LoadDamageButton()
    {
        if (this._damageButton != null) return;
        this._damageButton = GetComponentInChildren<DamageButton>();
        Debug.LogWarning(transform.name + ": LoadDamageButton", gameObject);
    }

    void LoadAttackButton()
    {
        if (this._attackButton != null) return;
        this._attackButton = GetComponentInChildren<AttackButton>();
        Debug.LogWarning(transform.name + ": LoadAttackButton", gameObject);
    }

    void LoadEggLoadButton()
    {
        if (this._eggLoadButton != null) return;
        this._eggLoadButton = GetComponentInChildren<EggLoadButton>();
        Debug.LogWarning(transform.name + ": LoadEggLoadButton", gameObject);
    }

    void LoadMoneyButton()
    {
        if (this._moneyButton != null) return;
        this._moneyButton = GetComponentInChildren<MoneyButton>();
        Debug.LogWarning(transform.name + ": LoadMoneyButton", gameObject);
    }

    void LoadChickenPriceButton()
    {
        if (this._chickenPriceButton != null) return;
        this._chickenPriceButton = GetComponentInChildren<ChickenPriceButton>();
        Debug.LogWarning(transform.name + ": LoadChickenPriceButton", gameObject);
    }

    public void CheckPriceAll()
    {
        this._damageButton.CheckPrice();
        this._attackButton.CheckPrice();
        this._eggLoadButton.CheckPrice();
        this._moneyButton.CheckPrice();
        this._chickenPriceButton.CheckPrice();
    }    

}
