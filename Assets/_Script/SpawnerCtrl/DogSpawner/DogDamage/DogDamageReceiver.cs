using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDamageReceiver : DamageReceiver, IObserverListener
{
    [Header("Dog Damage Receiver")]
    [SerializeField] private DogPrefabCtrl _dogPrefabCtrl;

    protected override void OnEnable()
    {
        base.OnEnable();
        ObserverManager.Instance.RegisterEvent(EventType.BulletCollideWithDog, this);
    }

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

    public void NotifyEvent(EventType type, object data)
    {
        BulletData bulletData = (BulletData)data;
        GameObject objReceiveDamage = bulletData.objReceiveDamage;
        if (objReceiveDamage != transform.parent.gameObject) return;
        int damage = bulletData.damage;
        this.Deduct(damage);
    }


}
