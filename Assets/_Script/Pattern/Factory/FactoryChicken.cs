using System.Linq;
using UnityEngine;

public class FactoryChicken : Factory<ChickenProduct>
{    
    
    public override IProduct GetProduct(Vector3 position, int id)
    {
        ChickenProduct product = productChickens[id];
        holder = GetHolder();
        ChickenProduct newProduct = Instantiate(product, position, Quaternion.identity, holder);
        newProduct.Initialize();
        return newProduct;
    }
    

    private Transform GetHolder()
    {
        return FindObjectOfType<LobbyCtrl>().CheckLobbyEmpty();
    }
}
