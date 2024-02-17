using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseListTranform : LoboMonoBehaviour
{
    
    [SerializeField] private List<Transform> tranforms = new List<Transform>();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTranforms();
    }

    void LoadTranforms()
    {
        if (this.tranforms.Count > 0) return;

        foreach (Transform transform in transform)
        {
            this.tranforms.Add(transform);
            transform.gameObject.SetActive(false);
        }
    }

    public void OnEnableTranform(int index)
    {
        this.tranforms[index].gameObject.SetActive(true);
    }

}
