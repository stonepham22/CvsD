using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : BaseSpawner, IObserverListener
{
    
    public void Spawning(Vector3 spawnPos, int damage)
    {
        GameObject prefab = this.RandomPrefab();
        // Set the damage value for the prefab
        Quaternion rotation = transform.parent.rotation;
        GameObject newBullet = this.Spawn(prefab, spawnPos, rotation);
        newBullet.SetActive(true);
    }

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.BulletDespawn, this);
        ObserverManager.Instance.RegisterEvent(EventType.BulletCollideWithDog, this);
        ObserverManager.Instance.RegisterEvent(EventType.ChickenShooting, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.ChickenShooting)
        {
            ChickenShootingData shootingData = (ChickenShootingData)data;
            this.Spawning(shootingData.bulletSpawnPos, shootingData.chickenDamage);
            return;
        }
        BulletData bulletData = data as BulletData;
        GameObject prefab = bulletData.bulletPrefab;
        this.Despawn(prefab);
    }

}
