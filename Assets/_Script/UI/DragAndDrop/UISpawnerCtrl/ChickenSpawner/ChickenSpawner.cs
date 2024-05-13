using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : BaseSpawner
{

    [SerializeField] public Transform Holder => holder;
    [SerializeField] private Transform _parent;
    void ChickenSpawnInLobby(GameObject prefab)
    {
        this._parent = UICtrl.Instance.DragAndDrop.ContainersCtrl.LobbyCtrl.CheckLobbyEmpty();
        if (this._parent == null) return;
        Vector3 spawnPos = transform.position;
        GameObject obj = this.Spawn(prefab, spawnPos, Quaternion.identity);
        obj.SetActive(true);
    }

    public void ChickenZeroSpawnInLobby()
    {
        this.ChickenSpawnInLobby(this.prefabs[0]);
    }
    
    public void ChickenSpawnInLobbyFromEgg()
    {
        int wave = WaveManager.Instance.CurrentWave;
        int prefabNumber = Random.Range(0, wave+1);
        this.ChickenSpawnInLobby(this.prefabs[prefabNumber]);
    }

    protected override void SetParentNewPrefab(GameObject newPrefab)
    {
        newPrefab.transform.SetParent(this._parent, false);
    }

    public virtual void SetFalseIsSelectedAllChickenPrefab()
    {
        ChickenPrefab[] allChickens = FindObjectsOfType<ChickenPrefab>();
        foreach (ChickenPrefab chicken in allChickens)
        {
            chicken.SetFalseIsSelected();
        }
    }

}
