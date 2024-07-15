using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : BaseSpawner, IObserverListener
{

    [SerializeField] public Transform Holder => holder;
    [SerializeField] private Transform _parent;

    private void Start()
    {
        RegistEvent();
    }

    private void RegistEvent()
    {
        List<EventType> eventTypes = new List<EventType>()
        {
            EventType.BuyChicken,
            EventType.ChickenOnDead
        };
        ObserverManager.Instance.RegistEvent(eventTypes, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        switch (type)
        {
            case EventType.BuyChicken:
                ChickenZeroSpawnInLobby();
                break;
            default:
                HandleChickenOnDead(data);
                break;
        }
    }
    private void HandleChickenOnDead(object data)
    {
        if(data is GameObject prefab)
        {
            Despawn(prefab);
        }
    }

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
        int prefabNumber = Random.Range(0, wave + 1);
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
