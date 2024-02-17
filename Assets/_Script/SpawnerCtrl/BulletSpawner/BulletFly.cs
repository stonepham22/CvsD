using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Vector3 _direction = Vector3.right;

    void Update()
    {
        transform.parent.Translate(this._direction * this._moveSpeed * Time.deltaTime);
    }

}
