using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : LoboMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;

    [SerializeField] protected int currentPrefabs = 0;
    public int CurrentPrefabs => currentPrefabs;

    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    [SerializeField] protected List<GameObject> prefabs;
    public Dictionary<GameObject, List<GameObject>> dicPool = new Dictionary<GameObject, List<GameObject>>();

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab.gameObject);
        }

        this.HidePrefabs();

        Debug.Log(name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (GameObject prefab in prefabs)
        {
            prefab.SetActive(false);
        }
    }

    public virtual GameObject Spawn(GameObject prefab, Vector3 spawnPos, Quaternion rotation)
    {
        GameObject newPrefab = GetObjectFromPool(prefab);
        newPrefab.transform.SetPositionAndRotation(spawnPos, rotation);

        SetParentNewPrefab(newPrefab);
        currentPrefabs++;
        spawnedCount++;
        return newPrefab;
    }

    protected virtual void SetParentNewPrefab(GameObject newPrefab)
    {
        newPrefab.transform.parent = holder;
    }

    protected virtual GameObject GetObjectFromPool(GameObject prefab)
    {
        if (dicPool.ContainsKey(prefab) && dicPool[prefab].Count > 0)
        {
            GameObject obj = dicPool[prefab][0];
            dicPool[prefab].RemoveAt(0);
            return obj;
        }

        GameObject newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(GameObject obj)
    {
        obj.SetActive(false);
        if (!dicPool.ContainsKey(obj)) dicPool[obj] = new List<GameObject>();
        
        dicPool[obj].Add(obj);
        currentPrefabs--;
        obj.transform.SetParent(holder, false);
    }

    public virtual GameObject RandomPrefab()
    {
        int rand = Random.Range(0, prefabs.Count);
        return prefabs[rand];
    }
}
