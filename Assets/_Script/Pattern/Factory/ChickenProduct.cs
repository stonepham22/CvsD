using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenProduct : MonoBehaviour, IProduct
{

    public void Initialize()
    {
        transform.gameObject.SetActive(true);
    }
}
