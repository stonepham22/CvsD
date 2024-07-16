using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IProduct iProduct = transform.GetComponent<IProduct>();
        if(iProduct != null)
        {
            Debug.Log(transform.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
