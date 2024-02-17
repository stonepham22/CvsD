using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerManager : LoboMonoBehaviour
{

    [SerializeField] protected PlayerManager playerManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerManager();
    }

    void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = GetComponentInParent<PlayerManager>();
        Debug.LogWarning(transform.name + ": LoadPlayerManager", gameObject);
    }

}
