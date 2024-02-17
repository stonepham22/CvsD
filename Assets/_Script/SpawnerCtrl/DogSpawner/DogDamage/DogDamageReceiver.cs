using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDamageReceiver : DamageReceiver
{
    [Header("Dog Damage Receiver")]
    [SerializeField] private DogPrefabCtrl _dogPrefabCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDogPrefabCtrl();
    }

    void LoadDogPrefabCtrl()
    {
        if (this._dogPrefabCtrl != null) return;
        this._dogPrefabCtrl = GetComponentInParent<DogPrefabCtrl>();
        Debug.LogWarning(transform.name + ": LoadDogPrefabCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this._dogPrefabCtrl.Animation.SetDead();
        Invoke(nameof(DogDespawn), 1f);
        this.SendReward();
    }

    void DogDespawn()
    {
        this._dogPrefabCtrl.Despawn.Despawning();
    }

    void SendReward()
    {
        this._dogPrefabCtrl.DogKillReward.SendReward();
    }

}
