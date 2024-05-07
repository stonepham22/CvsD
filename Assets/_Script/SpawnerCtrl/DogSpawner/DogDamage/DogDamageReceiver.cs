using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDamageReceiver : DamageReceiver
{
    [Header("Dog Damage Receiver")]
    [SerializeField] private DogPrefabCtrl _dogPrefabCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDogPrefabCtrl();
    }

    private void LoadDogPrefabCtrl()
    {
        if (this._dogPrefabCtrl != null) return;
        this._dogPrefabCtrl = GetComponentInParent<DogPrefabCtrl>();
        Debug.LogWarning(transform.name + ": LoadDogPrefabCtrl", gameObject);
    }

    protected override void OnDead()
    {
        Transform prefab = transform.parent.parent;
        ObserverManager.Instance.NotifyEvent(EventType.DogOnDead, prefab);
    }

}
