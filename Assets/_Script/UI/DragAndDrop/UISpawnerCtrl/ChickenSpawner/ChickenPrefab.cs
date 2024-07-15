using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChickenPrefab : ObjectDragAndDrop
{
    [Header("Chicken")]
    [SerializeField] const string STANDY = "Standy";

    [SerializeField] private ChickenPrefabDespawn _chickenPrefabDespawn;
    public ChickenPrefabDespawn Despawn => _chickenPrefabDespawn;

    protected override void CheckIsCanDrag()
    {
        string parentName = transform.parent.name;
        if (parentName.Substring(0, Math.Min(6, parentName.Length)) != STANDY) return;
        this.isCanDrag = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadChickenPrefabDespawn();
    }

    void LoadChickenPrefabDespawn()
    {
        if (this._chickenPrefabDespawn != null) return;
        this._chickenPrefabDespawn = GetComponentInChildren<ChickenPrefabDespawn>();
        Debug.LogWarning(transform.name + ": LoadChickenPrefabDespawn", gameObject);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ShieldSpawner.OnEnableShieldUpgradeButtonOff();
    }

}
