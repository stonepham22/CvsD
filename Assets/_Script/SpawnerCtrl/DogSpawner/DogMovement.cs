using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : LoboMonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 0.3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
    }

    void LoadRigidbody2D()
    {
        if (this._rigidbody2D != null) return;
        this._rigidbody2D = GetComponentInParent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

    private void OnEnable()
    {
        this.Moving();
    }

    private void Start()
    {
        this.Moving();
    }

    public void Moving()
    {
        this._rigidbody2D.velocity = new Vector2(-this._speed, 0f);
    }

    public void Stop()
    {
        this._rigidbody2D.velocity = Vector2.zero;
    }    

}
