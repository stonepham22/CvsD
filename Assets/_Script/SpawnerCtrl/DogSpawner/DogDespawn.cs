using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDespawn : MonoBehaviour
{
    
    public void Despawning()
    {
        SpawnerCtrl.Instance.DogSpawner.Despawn(transform.parent);
    }

}
