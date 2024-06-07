using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPrefabCtrl : LoboMonoBehaviour
{

    [SerializeField] private DogMovement _dogMovement;
    public DogMovement DogMovement => _dogMovement;

    [SerializeField] private DogDamageReceiver _damageReceiver;
    public DogDamageReceiver DamageReceiver => _damageReceiver;

    [SerializeField] private DogAnimation _dogAnimation;
    public DogAnimation Animation => _dogAnimation;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDogMovement();
        this.LoadDogDamageReceiver();
        this.LoadDogAnimation();
    }

    private void LoadDogMovement()
    {
        if (this._dogMovement != null) return;
        this._dogMovement = GetComponentInChildren<DogMovement>();
        Debug.LogWarning(transform.name + ": LoadDogMovement", gameObject);
    }

    private void LoadDogDamageReceiver()
    {
        if (this._damageReceiver != null) return;
        this._damageReceiver = GetComponentInChildren<DogDamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDogDamageReceiver", gameObject);
    }

    private void LoadDogAnimation()
    {
        if (this._dogAnimation != null) return;
        this._dogAnimation = GetComponentInChildren<DogAnimation>();
        Debug.LogWarning(transform.name + ": LoadDogAnimation", gameObject);
    }

}
