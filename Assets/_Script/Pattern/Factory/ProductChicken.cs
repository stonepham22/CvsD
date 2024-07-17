using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductChicken : MonoBehaviour, IProduct
{

    public void Initialize()
    {
        transform.gameObject.SetActive(true);
    }
}
