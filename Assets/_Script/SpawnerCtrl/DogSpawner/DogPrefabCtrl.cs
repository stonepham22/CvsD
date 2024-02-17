using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPrefabCtrl : LoboMonoBehaviour
{

    [SerializeField] private Animator _animator;
    public Animator Animator => _animator;

    [SerializeField] private DogMovement _dogMovement;
    public DogMovement DogMovement => _dogMovement;

    [SerializeField] private DogDespawn _dogDespawn;
    public DogDespawn Despawn => _dogDespawn;

    [SerializeField] private DogDamageReceiver _damageReceiver;
    public DogDamageReceiver DamageReceiver => _damageReceiver;

    [SerializeField] private DogAnimation _dogAnimation;
    public DogAnimation Animation => _dogAnimation;

    [SerializeField] private DogKillReward _dogKillReward;
    public DogKillReward DogKillReward => _dogKillReward;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadDogMovement();
        this.LoadDogDespawn();
        this.LoadDogDamageReceiver();
        this.LoadDogAnimation();
        this.LoadDogSendExp();
    }

    void LoadAnimator()
    {
        if (this._animator != null) return;
        this._animator = GetComponentInChildren<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }

    void LoadDogMovement()
    {
        if (this._dogMovement != null) return;
        this._dogMovement = GetComponentInChildren<DogMovement>();
        Debug.LogWarning(transform.name + ": LoadDogMovement", gameObject);
    }

    void LoadDogDespawn()
    {
        if (this._dogDespawn != null) return;
        this._dogDespawn = GetComponentInChildren<DogDespawn>();
        Debug.LogWarning(transform.name + ": LoadDogSpawner", gameObject);
    }

    void LoadDogDamageReceiver()
    {
        if (this._damageReceiver != null) return;
        this._damageReceiver = GetComponentInChildren<DogDamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDogDamageReceiver", gameObject);
    }

    void LoadDogAnimation()
    {
        if (this._dogAnimation != null) return;
        this._dogAnimation = GetComponentInChildren<DogAnimation>();
        Debug.LogWarning(transform.name + ": LoadDogAnimation", gameObject);
    }

    void LoadDogSendExp()
    {
        if (this._dogKillReward != null) return;
        this._dogKillReward = GetComponentInChildren<DogKillReward>();
        Debug.LogWarning(transform.name + ": LoadDogSendExp", gameObject);
    }

}
