using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsCtrl : LoboMonoBehaviour
{

    [SerializeField] private EggsButtonOn _eggsButtonOn;
    [SerializeField] private float _timer;    
    [SerializeField] private float _cooldown = 5f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEggsButtonOn();
    }

    void LoadEggsButtonOn()
    {
        if (this._eggsButtonOn != null) return;
        this._eggsButtonOn = GetComponentInChildren<EggsButtonOn>();
        Debug.LogWarning(transform.name + ": LoadEggsButtonOn", gameObject);
    }

    private void FixedUpdate()
    {
        this.EggsCooldown();
    }

    void EggsCooldown()
    {
        if (this._eggsButtonOn.gameObject.activeSelf) return;
        this._timer += Time.fixedDeltaTime;
        if (this._timer < this._cooldown) return;
        this._timer = 0;
        this.OnEnableEggsButtonOn();
    }

    void OnEnableEggsButtonOn()
    {
        this._eggsButtonOn.gameObject.SetActive(true);
    }

}
