using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class BulletDamageSender : DamageSender
{

    [SerializeField] private const string DOG_TAG = "Dog";
    [SerializeField] private const string DAMAGE_RECEIVER = "DamageReceiver";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(DOG_TAG)) return;
        if (collision.name != DAMAGE_RECEIVER) return;

        BulletData bulletData = new BulletData();
        bulletData.objReceiveDamage = collision.transform.parent.gameObject;
        bulletData.damage = this.damage;
        bulletData.bulletPrefab = transform.parent.gameObject;
        ObserverManager.Instance.NotifyEvent(EventType.BulletCollideWithDog, bulletData);
    }

    

}
/*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(DOG_TAG)) return;
        if (collision.name != DAMAGE_RECEIVER) return;
        DamageReceiver damageReceiver = collision.gameObject.GetComponent<DamageReceiver>();
        this.Send(damageReceiver);
    }
 */
/*public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DespawnBullet();
    }*/
/*void DespawnBullet()
    {
        this._ctrl.Despawn.Despawn();
    }*/
/* [SerializeField] private BulletPrefabCtrl _ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletPrefabCtrl();
    }

    void LoadBulletPrefabCtrl()
    {
        if (this._ctrl != null) return;
        this._ctrl = GetComponentInParent<BulletPrefabCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletPrefabCtrl", gameObject);
    }*/
