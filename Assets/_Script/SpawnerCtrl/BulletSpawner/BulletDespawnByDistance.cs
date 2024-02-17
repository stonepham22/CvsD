using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawnByDistance : MonoBehaviour
{

    [SerializeField] private float _distance = 10f;

    private void FixedUpdate()
    {
        this.Despawning();
    }

    public void Despawning()
    {
        if (this.CheckDistance()) return;
        this.Despawn();
    }

    public void Despawn()
    {
        SpawnerCtrl.Instance.BulletSpawner.Despawn(transform.parent);
    }

    bool CheckDistance()
    {
        if(transform.parent.position.x > this._distance) return false;
        return true;
    }

}
