using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPrefabDespawn : MonoBehaviour
{

    public void Despawning()
    {
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ChickenSpawner.Despawn(transform.parent.gameObject);
    }   

}
