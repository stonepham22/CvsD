using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
   
    public void Spawning(Vector3 spawnPos)
    {
        Transform prefab = this.RandomPrefab();
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = this.Spawn(prefab, spawnPos, rotation);
        newBullet.gameObject.SetActive(true);
    }    

}
