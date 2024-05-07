using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDogSendReward : LoboMonoBehaviour
{
    [Header("Base Dog Send Reward")]

    [SerializeField] protected int scale;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadScale();
    }

    void LoadScale()
    {
        string DogPrefabName = transform.parent.name;
        char dogPrefabIndex = DogPrefabName[DogPrefabName.Length - 1];
        this.scale = (int)Char.GetNumericValue(dogPrefabIndex);
        if (this.scale == 0) this.scale = 10;
    }

}
