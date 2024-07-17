using System.Linq;
using UnityEngine;

public class ConcreteFactoryChicken : Factory<ProductChicken>, IObserverListener
{    
    private void OnEnable()
    {
        ObserverManager.Instance.RegistEvent(EventType.BuyChicken, this);
    }
    
    public override IProduct GetProduct(Vector3 position, int id)
    {
        ProductChicken product = productChickens[id];
        holder = GetHolder();
        ProductChicken newProduct = Instantiate(product, position, Quaternion.identity, holder);
        newProduct.Initialize();
        return newProduct;
    }

    public void NotifyEvent(EventType type, object data)
    {
        GetProduct(new Vector3(0,0,0), 1);
    }

    private Transform GetHolder()
    {
        Lobby[] lobbies = FindObjectsOfType<Lobby>();
        Lobby lobby = lobbies.FirstOrDefault(lobby => lobby.transform.childCount == 0);
        return lobby?.transform;
    }
}
