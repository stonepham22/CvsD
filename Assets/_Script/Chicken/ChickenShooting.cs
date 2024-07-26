using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenShooting : LoboMonoBehaviour
{
    
    [SerializeField] private bool _isShooting = false;
    [SerializeField] private bool _isStandy = false;
    [SerializeField] private float _shootDelay = 5f;
    [SerializeField] private float _shootTimer = 0f;
    [SerializeField] private int _indexStandy;

    [SerializeField] private int _chickenDamage = 1;

    public void SetIsStandy(bool value)
    {
        this._isStandy = value;
    }

    private void FixedUpdate()
    {
        this.CheckIstandy();
        this.IsShooting();
        this.Shooting();
    }

    private void CheckIstandy()
    {
        string parentName = transform.parent.parent.name;
        if (parentName.Substring(0, 6) == "Standy")
        {
            this._isStandy = true;
            this.SetIndexStandy();
        } 
        
        else this._isStandy =  false;
    }

    private void SetIndexStandy()
    {
        string parentName = transform.parent.parent.name;
        char indexChar = parentName[parentName.Length - 1];
        this._indexStandy = int.Parse(indexChar.ToString());
    }

    private void IsShooting()
    {
        if(!this._isStandy) return;
        SpawnPosition spawnPosition = SpawnerCtrl.Instance.DogSpawner.SpawnPosition;
        if (spawnPosition.CheckDogPrefabInList(this._indexStandy)) this._isShooting = true;
        else this._isShooting = false;
    }

    private void Shooting()
    {
        if (!this._isShooting) return;
        if(!this._isStandy) return;
        if (this.CheckDelayTime()) return;

        ChickenShootingData data = new ChickenShootingData()
        {
            bulletSpawnPos = transform.parent.position,
            chickenDamage = this._chickenDamage
        };

        ObserverManager.Instance.NotifyEvent(EventType.ChickenShooting, data);

    }

    private bool CheckDelayTime()
    {
        this._shootTimer += Time.fixedDeltaTime;
        if (this._shootTimer < this._shootDelay) return true;
        this._shootTimer = 0;
        return false;
    }

}
