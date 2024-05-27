using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpawner : BaseSpawner, IObserverListener
{
    [Header("Dog Spawner")]
    [SerializeField] private SpawnPosition _spawnPosition;
    public SpawnPosition SpawnPosition => _spawnPosition;

    [SerializeField] private float _timer;
    [SerializeField] private float _timeDelay = 5f;
    [SerializeField] private Transform _spawnPoint;
    
    [SerializeField] private bool _isSpawn;
    public bool IsSpawn => _isSpawn;

    [SerializeField] private int _spawnCountLimiteInWave;

    protected void Start()
    {
        this.UpdateSpawnCountLimiteInWave();
        ObserverManager.Instance.RegisterEvent(EventType.DogDespawn, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        GameObject prefab = (GameObject)data;
        this.Despawn(prefab);
    }

    private void UpdateSpawnCountLimiteInWave()
    {
        this._spawnCountLimiteInWave = WaveManager.Instance.GetSpawnCountLimiteInWave();
        this.currentPrefabs = 0;
        this.spawnedCount = 0;
        this._isSpawn = true;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPosition();
    }

    protected virtual void LoadSpawnPosition()
    {
        if (this._spawnPosition != null) return;
        this._spawnPosition = GetComponentInChildren<SpawnPosition>();
        Debug.LogWarning(transform.name + ": LoadSpawnPosition", gameObject);
    }

    private void FixedUpdate()
    {
        this.Spawning();
        this.CheckNextWave();
    }

    private void CheckNextWave()
    {
        if (this._isSpawn) return;
        if (this.currentPrefabs > 0) return;
        this.NextWave();
        this.UpdateSpawnCountLimiteInWave();
    }

    private void Spawning()
    {
        if (!this._isSpawn) return;
        if (this.CheckTimeDelay()) return;
        this.Spawn();
        this.CheckSpawnedEnemiesCount();
    }

    private void Spawn()
    {
        GameObject prefab = this.RandomPrefab();
        Transform spawnPoint = this._spawnPosition.RamdomSpawnPoint();
        this._spawnPoint = spawnPoint;
        Vector3 spawnPos = spawnPoint.position;
        GameObject obj = this.Spawn(prefab, spawnPos, Quaternion.identity);
        obj.SetActive(true);
    }    

    private void CheckSpawnedEnemiesCount()
    {
        if (this.spawnedCount < _spawnCountLimiteInWave) return;
        this._isSpawn = false;
    }    

    private void NextWave()
    {
        ObserverManager.Instance.NotifyEvent(EventType.NextWave, null);
    }    

    protected override void SetParentNewPrefab(GameObject newPrefab)
    {
        newPrefab.transform.parent = this._spawnPoint;
    }

    bool CheckTimeDelay()
    {
        if(this._timer < this._timeDelay)
        {
            this._timer += Time.fixedDeltaTime;
            return true;
        }
        this._timer = 0;
        return false;
    }

}
