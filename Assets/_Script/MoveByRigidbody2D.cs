using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByRigidbody2D : LoboMonoBehaviour
{
    
    [SerializeField] protected Rigidbody2D rigidbody2d;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
    }

    void LoadRigidbody2D()
    {
        if (this.rigidbody2d != null) return;
        this.rigidbody2d = GetComponentInParent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

}
