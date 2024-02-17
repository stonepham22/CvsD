using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    [SerializeField] private Vector3 _mouseWorldPos;
    public Vector3 MouseWorldPos => _mouseWorldPos;

    [SerializeField] private bool _isMouseDown;
    public bool IsMouseDown => _isMouseDown;

    [SerializeField] private Ray _mouseRay;
    public Ray MouseRay => _mouseRay;

    private void FixedUpdate()
    {
        this.GetMousePos();
        this.GetMouseDown();
        this.GetMouseRay();
    }
   
    void GetMousePos()
    {
        this._mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void GetMouseDown()
    {
        this._isMouseDown = Input.GetMouseButton(0);
    }

    void GetMouseRay()
    {
        this._mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    }    


}
