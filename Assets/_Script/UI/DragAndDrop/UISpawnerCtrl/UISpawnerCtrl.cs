using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawnerCtrl : LoboMonoBehaviour
{

    [SerializeField] private ChickenSpawner _chickenSpawner;
    public ChickenSpawner ChickenSpawner => _chickenSpawner;

    [SerializeField] private ShieldSpawner _shieldSpawner;
    public ShieldSpawner ShieldSpawner => _shieldSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadChickenSpawner();
        this.LoadShieldSpawner();
    }

    void LoadChickenSpawner()
    {
        if (this._chickenSpawner != null) return;
        this._chickenSpawner = GetComponentInChildren<ChickenSpawner>();
        Debug.LogWarning(transform.name + ": LoadChickenSpawner", gameObject);
    }

    void LoadShieldSpawner()
    {
        if (this._shieldSpawner != null) return;
        this._shieldSpawner = GetComponentInChildren<ShieldSpawner>();
        Debug.LogWarning(transform.name + ": LoadShieldSpawner", gameObject);
    }

}
