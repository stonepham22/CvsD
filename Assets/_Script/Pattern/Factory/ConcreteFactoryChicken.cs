using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConcreteFactoryChicken : Factory
{
    // [SerializeField] private List<ProductChicken> _productChickens = new List<ProductChicken>();
   
    // public override IProduct GetProduct(Vector3 position)
    // {
    //     // create a Prefab instance and get the product component
    //     GameObject instance = Instantiate(_productChickens[RandomIndex()].gameObject, position, Quaternion.identity);
    //     ProductChicken newProduct = instance.GetComponent<ProductChicken>();

    //     // each product contains its own logic
    //     newProduct.Initialize();

    //     return newProduct;
    // }

    // private int RandomIndex()
    // {
    //     return Random.Range(0, _productChickens.Count);
    // }

    public override IProduct GetProduct(Vector3 position, int chickenId)
    {
        IProduct product = new ProductChicken();
        
        switch(chickenId)
        {
            case 1:
                product = new ProductChicken01();
                break;
            case 2:
                product = new ProductChicken02();
                break;
            case 3:
                product = new ProductChicken03();
                break;
            case 4:
                product = new ProductChicken04();
                break;
            case 5:
                product = new ProductChicken05();
                break;
            case 6:
                product = new ProductChicken06();
                break;
            case 7:
                product = new ProductChicken07();
                break;
            case 8:
                product = new ProductChicken08();
                break;
            case 9:
                product = new ProductChicken09();
                break;
            case 10:
                product = new ProductChicken10();
                break;    
        }

        return product;
    }

}
