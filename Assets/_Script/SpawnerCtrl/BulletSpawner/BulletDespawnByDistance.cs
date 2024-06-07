using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawnByDistance : MonoBehaviour
{

    [SerializeField] private float _distance = 10f;

    private void FixedUpdate()
    {
        this.CheckBulletOverScreen();
    }

    private void CheckBulletOverScreen()
    {
        if (IsOverScreen()) this.Despawn();
    }

    private void Despawn()
    {
        BulletData bulletData = new BulletData();
        bulletData.bulletPrefab = transform.parent.gameObject;
        ObserverManager.Instance.NotifyEvent(EventType.BulletDespawn, bulletData);
    }

    private bool IsOverScreen()
    {
        if(transform.parent.position.x > this._distance) return true;
        return false;
    }

}
