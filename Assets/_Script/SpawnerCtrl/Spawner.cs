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

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Dictionary<string, List<Transform>> dicPool = new Dictionary<string, List<Transform>>();

    protected override void LoadComponents()
    {
        LoadPrefabs();
        LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
        Debug.Log(name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
        }

        HidePrefabs();

        Debug.Log(name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }

        return Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        SetParentNewPrefab(newPrefab);
        currentPrefabs++;
        spawnedCount++;
        return newPrefab;
    }

    protected virtual void SetParentNewPrefab(Transform newPrefab)
    {
        newPrefab.parent = holder;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        string prefabName = prefab.name;
        if (dicPool.ContainsKey(prefabName) && dicPool[prefabName].Count > 0)
        {
            Transform obj = dicPool[prefabName][0];
            dicPool[prefabName].RemoveAt(0);
            return obj;
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefabName;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        string prefabName = obj.name;
        if (!dicPool.ContainsKey(prefabName))
        {
            dicPool[prefabName] = new List<Transform>();
        }

        dicPool[prefabName].Add(obj);
        obj.gameObject.SetActive(false);
        currentPrefabs--;
        obj.SetParent(holder, false);
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }

    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, prefabs.Count);
        return prefabs[rand];
    }
}
