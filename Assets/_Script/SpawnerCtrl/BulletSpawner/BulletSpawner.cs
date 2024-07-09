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
        BulletDamageSender bulletDamageSender = newBullet.GetComponentInChildren<BulletDamageSender>();
        bulletDamageSender.SetDamage(damage);
        newBullet.SetActive(true);
    }

    private void Start()
    {
        this.RegisterEvent();
    }
    
    private void RegisterEvent()
    {
        List<EventType> types = new List<EventType>
        {
            EventType.BulletDespawn,
            EventType.BulletCollideWithDog,
            EventType.ChickenShooting
        };
        ObserverManager.Instance.RegistEvent(types, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        switch(type)
        {
            case EventType.ChickenShooting:
                this.HandleChickenShooting(data);
                break;
            default:
                this.HandleDespawnBullet(data);
                break;
        }
    }
    private void HandleChickenShooting(object data)
    {
        if(data is ChickenShootingData shootingData)
        {
            this.Spawning(shootingData.bulletSpawnPos, shootingData.chickenDamage);
        }
    }
    private void HandleDespawnBullet(object data)
    {
        if(data is BulletData bulletData)
        {
            GameObject prefab = bulletData.bulletPrefab;
            this.Despawn(prefab);
        }
    }
}
