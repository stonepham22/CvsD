using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPrefabDespawn : MonoBehaviour
{

    public void Despawning()
    {
        //Transform holder = UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ChickenSpawner.Holder;
        //transform.parent.SetParent(holder, false);
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ChickenSpawner.Despawn(transform.parent.gameObject);
    }   

}
