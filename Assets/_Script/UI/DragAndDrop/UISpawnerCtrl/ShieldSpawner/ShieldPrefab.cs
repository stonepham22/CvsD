using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShieldPrefab : ObjectDragAndDrop
{
    [Header("Shield Prefab")]
    [SerializeField] const string SHIELD = "Shield";
    [SerializeField] private ShieldModel _shieldModel;
    [SerializeField] private ShieldPrefabUpgrade _upgrade;
    public ShieldPrefabUpgrade Upgrade => _upgrade;
    
    [SerializeField] private ShieldPrefabRepair _repair;
    public ShieldPrefabRepair Repair => _repair;

    [SerializeField] private ShieldDamageReceiver _damageReceiver;
    public ShieldDamageReceiver DamageReceiver => _damageReceiver;

    [SerializeField] private ShieldPrefabDespawn _shieldPrefabDespawn;
    public ShieldPrefabDespawn Despawn => _shieldPrefabDespawn;

    protected override void CheckIsCanDrag()
    {
        string parentName = transform.parent.name;
        if (parentName.Substring(0, Math.Min(6, parentName.Length)) != SHIELD) return;
        this.isCanDrag = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldModel();
        this.LoadShieldPrefabUpgrade();
        this.LoadShieldDamageReceiver();
        this.LoadShieldPrefabRepair();
        this.LoadShieldPrefabDespawn();
    }

    void LoadShieldModel()
    {
        if (this._shieldModel != null) return;
        this._shieldModel = GetComponentInChildren<ShieldModel>();
        Debug.LogWarning(transform.name + ": LoadShieldModel", gameObject);
    }

    void LoadShieldPrefabUpgrade()
    {
        if (this._upgrade != null) return;
        this._upgrade = GetComponentInChildren<ShieldPrefabUpgrade>();
        Debug.LogWarning(transform.name + ": LoadShieldPrefabUpgrade", gameObject);
    }

    void LoadShieldDamageReceiver()
    {
        if (this._damageReceiver != null) return;
        this._damageReceiver = GetComponentInChildren<ShieldDamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadShieldDamageReceiver", gameObject);
    }

    void LoadShieldPrefabRepair()
    {
        if (this._repair != null) return;
        this._repair = GetComponentInChildren<ShieldPrefabRepair>();
        Debug.LogWarning(transform.name + ": LoadShieldPrefabRepair", gameObject);
    }

    void LoadShieldPrefabDespawn()
    {
        if (this._shieldPrefabDespawn != null) return;
        this._shieldPrefabDespawn = GetComponentInChildren<ShieldPrefabDespawn>();
        Debug.LogWarning(transform.name + ": LoadShieldPrefabDespawn", gameObject);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        this._upgrade.ShieldPrefabUpgrading();
        this._repair.ShieldPrefabRepairing();
    }

}
