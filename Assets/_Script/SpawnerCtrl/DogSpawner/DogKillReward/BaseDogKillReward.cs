using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDogKillReward : LoboMonoBehaviour
{

    [SerializeField] protected DogKillReward dogKillReward;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDogKillReward();
    }

    void LoadDogKillReward()
    {
        if (this.dogKillReward != null) return;
        this.dogKillReward = GetComponentInParent<DogKillReward>();
        Debug.LogWarning(transform.name + ": LoadDogKillReward", gameObject);
    }

}
