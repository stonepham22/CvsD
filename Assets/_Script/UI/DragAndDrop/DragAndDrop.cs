using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : LoboMonoBehaviour
{

    [SerializeField] private ContainersCtrl _containersCtrl;
    public ContainersCtrl ContainersCtrl => _containersCtrl;

    [SerializeField] private UISpawnerCtrl _uiSpawnerCtrl;
    public UISpawnerCtrl UISpawnerCtrl => _uiSpawnerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContainersCtrl();
        this.LoadUISpawnerCtrl();
    }

    void LoadContainersCtrl()
    {
        if (this._containersCtrl != null) return;
        this._containersCtrl = GetComponentInChildren<ContainersCtrl>();
        Debug.LogWarning(transform.name + ": LoadContainersCtrl", gameObject);
    }

    void LoadUISpawnerCtrl()
    {
        if (this._uiSpawnerCtrl != null) return;
        this._uiSpawnerCtrl = GetComponentInChildren<UISpawnerCtrl>();
        Debug.LogWarning(transform.name + ": LoadUISpawnerCtrl", gameObject);
    }

}
