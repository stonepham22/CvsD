using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShieldPrefab : LoboMonoBehaviour
{

    [SerializeField] protected ShieldPrefab shieldPrefab;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldPrefab();
    }

    void LoadShieldPrefab()
    {
        if (this.shieldPrefab != null) return;
        this.shieldPrefab = GetComponentInParent<ShieldPrefab>();
        Debug.LogWarning(transform.name + ": LoadShieldPrefab", gameObject);
    }

}
