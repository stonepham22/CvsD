using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : BaseSpawner, IObserverListener
{
    
    public void Spawning(Vector3 spawnPos)
    {
        GameObject prefab = this.RandomPrefab();
        Quaternion rotation = transform.parent.rotation;
        GameObject newBullet = this.Spawn(prefab, spawnPos, rotation);
        newBullet.SetActive(true);
    }

    private void Start()
    {
        ObserverManager.Instance.RegisterEvent(EventType.BulletDespawn, this);
        ObserverManager.Instance.RegisterEvent(EventType.BulletCollideWithDog, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        BulletData bulletData = data as BulletData;
        GameObject prefab = bulletData.bulletPrefab;
        this.Despawn(prefab);
    }

}
