using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
   
    public void Spawning(Vector3 spawnPos)
    {
        GameObject prefab = this.RandomPrefab();
        Quaternion rotation = transform.parent.rotation;
        GameObject newBullet = this.Spawn(prefab, spawnPos, rotation);
        newBullet.SetActive(true);
    }    

}
