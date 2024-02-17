using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : LoboMonoBehaviour
{

    private static SpawnerCtrl _instance;
    public static SpawnerCtrl Instance => _instance;

    [SerializeField] private DogSpawner _dogSpawner;
    public DogSpawner DogSpawner => _dogSpawner;

    [SerializeField] private BulletSpawner _bulletSpawner;
    public BulletSpawner BulletSpawner => _bulletSpawner;

    protected override void Awake()
    {
        if (SpawnerCtrl._instance != null) Debug.LogError("only 1 UICtrl allow to exist");
        SpawnerCtrl._instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDogSpawner();
        this.LoadBulletSpawner();
    }

    void LoadDogSpawner()
    {
        if (this._dogSpawner != null) return;
        this._dogSpawner = GetComponentInChildren<DogSpawner>();
        Debug.LogWarning(transform.name + ": LoadDogSpawner", gameObject);
    }

    void LoadBulletSpawner()
    {
        if (this._bulletSpawner != null) return;
        this._bulletSpawner = GetComponentInChildren<BulletSpawner>();
        Debug.LogWarning(transform.name + ": LoadBulletSpawner", gameObject);
    }

}
