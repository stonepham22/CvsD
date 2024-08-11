using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFactoryChicken : LoboMonoBehaviour, IObserverListener
{
    [SerializeField] private ChickenFactory _factoryChicken;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFactoryChicken();
    }
    
    void LoadFactoryChicken()
    {
        if(_factoryChicken != null) return;
        _factoryChicken = GetComponent<ChickenFactory>();
    }

    void OnEnable()
    {
        ObserverManager.Instance.RegistEvent(EventType.BuyChicken, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
    //    _factoryChicken.GetProduct(new Vector3(0,0,0), 1);
    }
    
}
