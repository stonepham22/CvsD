using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConcreteFactoryChicken : Factory<ProductChicken>
{

    public override ProductChicken GetProduct(Vector3 position, int id)
    {
        ProductChicken product = productChickens[id];
        holder = GameObject.Find("Lobby_1").transform;
        ProductChicken newProduct = Instantiate(product, position, Quaternion.identity, holder);
        newProduct.Initialize();
        return newProduct;
    }

}
