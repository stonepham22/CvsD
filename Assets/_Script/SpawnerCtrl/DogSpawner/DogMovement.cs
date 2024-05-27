using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MoveByRigidbody2D
{

    [SerializeField] private float _speed = 0.3f;

    private void OnEnable()
    {
        this.Moving();
    }

    public void Moving()
    {
        this.rigidbody2d.velocity = new Vector2(-this._speed, 0f);
    }

    public void Stop()
    {
        this.rigidbody2d.velocity = Vector2.zero;
    }    

}
