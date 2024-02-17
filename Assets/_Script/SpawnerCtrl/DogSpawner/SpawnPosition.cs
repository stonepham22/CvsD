using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : LoboMonoBehaviour
{

    [SerializeField] private List<Transform> _spawnPositions;
    public List<Transform> SpawnPositions => _spawnPositions;

    [SerializeField] private float _offsetShooting = -2;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPositions();
    }

    void LoadSpawnPositions()
    {
        if (this._spawnPositions.Count > 0) return;

        foreach (Transform spawnPos in transform)
        {
            this._spawnPositions.Add(spawnPos);
        }

        Debug.Log(transform.name + ": LoadSpawnPositions", gameObject);
    }

    public Transform RamdomSpawnPoint()
    {
        int index = Random.Range(0, this._spawnPositions.Count);
        Transform spawnPoint = this._spawnPositions[index];
        return spawnPoint;
    }

    public bool CheckDogPrefabInList(int indexStandy)
    {
        if (this._spawnPositions[indexStandy - 1].childCount == 0) return false;
        foreach (Transform dogPrefab in this._spawnPositions[indexStandy - 1])
        {
            if (!dogPrefab.gameObject.activeSelf) continue;
            if (dogPrefab.localPosition.x < this._offsetShooting) return true;
        }
        return false;
    }

}
