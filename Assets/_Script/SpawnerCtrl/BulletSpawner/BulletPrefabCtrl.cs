using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefabCtrl : LoboMonoBehaviour
{

    [SerializeField] private BulletDespawnByDistance _despawn;
    public BulletDespawnByDistance Despawn => _despawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawnByDistance();
    }

    void LoadBulletDespawnByDistance()
    {
        if (this._despawn != null) return;
        this._despawn = GetComponentInChildren<BulletDespawnByDistance>();
        Debug.LogWarning(transform.name + ": LoadBulletDespawnByDistance", gameObject);
    }

}
