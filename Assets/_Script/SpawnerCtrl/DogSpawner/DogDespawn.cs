using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDespawn : MonoBehaviour, IObserverListener
{

    private void OnEnable()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
    }

    private void OnDisable()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.DogOnDead, this);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.UnregisterEvent(EventType.DogOnDead, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        DogData dogData = (DogData)data;
        if (transform.parent == dogData.dogPrefab.transform) Invoke(nameof(Despawning), 1f);
    }

    private void Despawning()
    {
        ObserverManager.Instance.NotifyEvent(EventType.DogDespawn, transform.parent.gameObject);
    }

}
