using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : LoboMonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button button;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

    protected virtual void Start()
    {
        this.AddOnClickEvent();
    }

    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.LogWarning(transform.name + ": LoadButton", gameObject);
    }

    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected virtual void OnClick()
    {
        this.UnClickShieldPrefab();
        this.UnClickChickenPrefab();
    }

    private void UnClickShieldPrefab()
    {
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ShieldSpawner.DontUpgradeShield();
        UICtrl.Instance.GameplayScreen.BottomScreen.ShieldRepair.ButtonOff.gameObject.SetActive(true);
    }

    private void UnClickChickenPrefab()
    {
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ChickenSpawner.SetFalseIsSelectedAllChickenPrefab();
    }

}
