using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : LoboMonoBehaviour
{
    private static PoolManager _instance;
    public static PoolManager Instance => _instance;

    protected override void Awake()
    {
        if (PoolManager._instance != null) Debug.LogError("only 1 ManagerCtrl allow to exist");
        PoolManager._instance = this;
    }

    private Dictionary<GameObject, List<GameObject>> _poolingDict = new Dictionary<GameObject, List<GameObject>>();

    public GameObject GetObject(GameObject prefab)
    {
        if (!this._poolingDict.ContainsKey(prefab)) 
            this._poolingDict.Add(prefab, new List<GameObject>());

        List<GameObject> pools = _poolingDict[prefab];
        pools.RemoveAll(m => m == null);
        foreach (GameObject obj in pools)
        {
            if (obj.activeSelf) continue;
            return obj;
        }

        GameObject newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        _poolingDict[prefab].Add(newPrefab);
        return newPrefab;
    }

}
