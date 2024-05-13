using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDespawn : MonoBehaviour, IObserverListener
{

    private void Start()
    {
        this.RegisterEventDogOnDead();
    }

    public void NotifyEvent(object data)
    {
        if (transform.parent != (Transform)data) return;
        Invoke(nameof(Despawning), 1f);
    }

    private void RegisterEventDogOnDead()
    {
        ObserverManager.Instance.RegisterEvent(EventType.DogOnDead, this);
    }

    private void Despawning()
    {
        //SpawnerCtrl.Instance.DogSpawner.Despawn(transform.parent.gameObject);

        ObserverManager.Instance.NotifyEvent(EventType.DogDespawn, transform.parent.gameObject);
    }

}
