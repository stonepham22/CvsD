using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDogPrefab : LoboMonoBehaviour
{

    [SerializeField] protected DogPrefabCtrl dogPrefabCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDogPrefabCtrl();
    }

    void LoadDogPrefabCtrl()
    {
        if (this.dogPrefabCtrl != null) return;
        this.dogPrefabCtrl = GetComponentInParent<DogPrefabCtrl>();
        Debug.LogWarning(transform.name + ": LoadDogPrefabCtrl", gameObject);
    }

}
