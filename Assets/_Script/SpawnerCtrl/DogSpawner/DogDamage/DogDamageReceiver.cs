using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDamageReceiver : DamageReceiver, IObserverListener
{
    [Header("Dog")]
    [SerializeField] private int _expDefault = 10;
    [SerializeField] private int _coinDefault = 1;

    protected override void OnEnable()
    {
        base.OnEnable();
        ObserverManager.Instance.RegisterEvent(EventType.BulletCollideWithDog, this);
    }

    // private void OnDisable()
    // {
    //     ObserverManager.Instance.UnregisterEvent(EventType.BulletCollideWithDog, this);
    // }

    protected override void OnDead()
    {
        DogData dogData = new DogData()
        {
            dogPrefab = transform.parent.parent.gameObject,
            expDefault = _expDefault,
            coinDefault = _coinDefault,
        };
        
        ObserverManager.Instance.NotifyEvent(EventType.DogOnDead, dogData);
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
