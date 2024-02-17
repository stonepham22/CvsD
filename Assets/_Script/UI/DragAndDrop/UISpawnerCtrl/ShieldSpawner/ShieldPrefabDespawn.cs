using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPrefabDespawn : MonoBehaviour
{
    
    public void Despawning()
    {
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ShieldSpawner.Despawn(transform.parent);
    }

}
