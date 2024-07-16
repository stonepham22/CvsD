using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductChicken : MonoBehaviour, IProduct
{
    [SerializeField] private string _productName = "ProductChicken";
    public string ProductName { get => _productName; set => _productName = value ; }


    public void Initialize()
    {
        
    }
}
