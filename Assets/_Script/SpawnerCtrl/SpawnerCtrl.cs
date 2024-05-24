using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : BaseLazySingleton<SpawnerCtrl>
{

    [SerializeField] private DogSpawner _dogSpawner;
    public DogSpawner DogSpawner => _dogSpawner;

    [SerializeField] private BulletSpawner _bulletSpawner;
    public BulletSpawner BulletSpawner => _bulletSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDogSpawner();
        this.LoadBulletSpawner();
    }

    private void LoadDogSpawner()
    {
        if (this._dogSpawner != null) return;
        this._dogSpawner = GetComponentInChildren<DogSpawner>();
        Debug.LogWarning(transform.name + ": LoadDogSpawner", gameObject);
    }

    private void LoadBulletSpawner()
    {
        if (this._bulletSpawner != null) return;
        this._bulletSpawner = GetComponentInChildren<BulletSpawner>();
        Debug.LogWarning(transform.name + ": LoadBulletSpawner", gameObject);
    }

}
