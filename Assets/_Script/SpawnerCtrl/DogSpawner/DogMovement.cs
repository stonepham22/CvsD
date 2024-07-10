using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MoveByRigidbody2D, IObserverListener
{

    [SerializeField] private float _speed = 0.3f;

    private void OnEnable()
    {
        RegistEvent();
        this.Move();
    }
    private void OnDisable()
    {
        UnregistEvent();
    }

    private void RegistEvent()
    {
        ObserverManager.Instance.RegistEvent(EventType.OnClickShoppingButtonOn, this);
    }
    private void UnregistEvent()
    {
        if(ObserverManager.Instance == null) return;
        ObserverManager.Instance.UnregistEvent(EventType.OnClickShoppingButtonOn, this);
    }

    public void Move()
    {
        this.rigidbody2d.velocity = new Vector2(-this._speed, 0f);
    }

    public void Stop()
    {
        this.rigidbody2d.velocity = Vector2.zero;
    }

    public void NotifyEvent(EventType type, object data)
    {
        Stop();
    }
}
