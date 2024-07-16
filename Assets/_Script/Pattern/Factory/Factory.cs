using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<T> : LoboMonoBehaviour
{
    protected List<T> productChickens = new List<T>();
    [SerializeField] protected Transform holder;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadProductChicken();
        LoadHolder();
    }
    void LoadProductChicken()
    {
        Transform prefabTransform = transform.Find("Prefabs");
        if (prefabTransform != null)
        {
            for (int i = 0; i < prefabTransform.childCount; i++)
            {
                Transform child = prefabTransform.GetChild(i);
                T chicken = child.GetComponent<T>();
                if (chicken != null)
                {
                    productChickens.Add(chicken);
                }
                child.gameObject.SetActive(false);
            }
        }
    }
    void LoadHolder()
    {
        holder = transform.Find("Holder");
        if (holder == null)
        {
            holder = new GameObject("Holder").transform;
            holder.SetParent(transform);
        }
    }
    
    public abstract T GetProduct(Vector3 position, int id);

}
