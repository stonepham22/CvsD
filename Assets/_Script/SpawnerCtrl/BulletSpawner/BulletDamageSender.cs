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
        NotifyEventBulletCollideWithDog(collision.transform.parent.gameObject);
    }
    private void NotifyEventBulletCollideWithDog(GameObject objReceiveDamage)
    {
        BulletData bulletData = new BulletData()
        {
            objReceiveDamage = objReceiveDamage,
            damage = this.damage,
            bulletPrefab = transform.parent.gameObject,
        };
        ObserverManager.Instance.NotifyEvent(EventType.BulletCollideWithDog, bulletData);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
