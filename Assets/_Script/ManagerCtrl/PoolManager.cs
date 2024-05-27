using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : BaseLazySingleton<PoolManager>
{
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
