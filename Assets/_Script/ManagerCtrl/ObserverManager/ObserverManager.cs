using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// The ObserverManager class is responsible for managing observers and notifying them of events.
/// </summary>
public class ObserverManager : BaseSingleton<ObserverManager>
{
    private ObserverManager() { }
    private Dictionary<EventType, HashSet<IObserverListener>> dicListeners = new Dictionary<EventType, HashSet<IObserverListener>>();

    public void RegisterEvent(EventType type, IObserverListener listener)
    {
        if (!dicListeners.TryGetValue(type, out var listeners))
        {
            listeners = new HashSet<IObserverListener>();
            dicListeners[type] = listeners;
        }
        listeners.Add(listener);
        // if ((listener.GetType()) == typeof(PlayerCoin))
        // {
        //     Debug.Log("RegisterEvent: " + type + " " + listener.GetType());
        // }
    }

    public void RegisterEvent(List<EventType> types, IObserverListener listener)
    {
        foreach (EventType type in types)
        {
            RegisterEvent(type, listener);
        }
    }

    public void UnregisterEvent(EventType type, IObserverListener listener)
    {
        if (dicListeners.TryGetValue(type, out var listeners))
        {
            listeners.Remove(listener);
        }
    }

    public void NotifyEvent(EventType type, object data)
    {
        if (dicListeners.TryGetValue(type, out var listeners))
        {
            foreach (IObserverListener listener in listeners)
            {
                listener.NotifyEvent(type, data);
            }
        }
    }
}