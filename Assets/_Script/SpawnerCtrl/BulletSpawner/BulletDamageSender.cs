using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class BulletDamageSender : DamageSender
{

    private const string DOG_TAG = "Dog";
    private const string DAMAGE_RECEIVER = "DamageReceiver";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(DOG_TAG)) return;
        if (collision.name != DAMAGE_RECEIVER) return;

        BulletData bulletData = new BulletData()
        {
            objReceiveDamage = collision.transform.parent.gameObject,
            damage = this.damage,
            bulletPrefab = transform.parent.gameObject,
        };

        ObserverManager.Instance.NotifyEvent(EventType.BulletCollideWithDog, bulletData);
    }

}
