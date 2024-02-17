using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenDamageReceiver : DamageReceiver
{

    [Header("Chicken DamageReceiver")]
    [SerializeField] private ChickenPrefab _chickenPrefab;
    public ChickenPrefab ChickenPrefab => _chickenPrefab;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadChichkenPrefab();
    }

    void LoadChichkenPrefab()
    {
        if (this._chickenPrefab != null) return;
        this._chickenPrefab = GetComponentInParent<ChickenPrefab>();
        Debug.LogWarning(transform.name + ": LoadChichkenPrefab", gameObject);
    }

    protected override void OnDead()
    {
        this._chickenPrefab.Despawn.Despawning();
    }

}
