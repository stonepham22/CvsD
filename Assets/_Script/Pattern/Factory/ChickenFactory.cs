using UnityEngine;

public class ChickenFactory : ScriptableObject
{
    private IChicken _chicken;

    public ChickenFactory()
    {
        _chicken = new Chicken01();
    }

    public IChicken SpawnChicken(Vector3 position)
    {
        // holder = GetHolder();
        // ChickenProduct newProduct = Instantiate(_chicken., position, _chicken., holder);
        // newProduct.Initialize();
        return _chicken;
    }
}

// public class ChickenFactory : Factory<ChickenProduct>
// {    
    
//     // public override IProduct GetProduct(Vector3 position, int id)
//     // {
//     //     ChickenProduct product = productChickens[id];
//     //     holder = GetHolder();
//     //     ChickenProduct newProduct = Instantiate(product, position, Quaternion.identity, holder);
//     //     newProduct.Initialize();
//     //     return newProduct;
//     // }
    

//     // private Transform GetHolder()
//     // {
//     //     return FindObjectOfType<LobbyCtrl>().CheckLobbyEmpty();
//     // }
// }
