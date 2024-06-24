using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObserverManager : BaseSingleton<ObserverManager>
{
    private ObserverManager() { }
    private Dictionary<EventType, List<IObserverListener>> dicListeners = new Dictionary<EventType, List<IObserverListener>>();

    public void RegisterEvent(EventType type, IObserverListener listener)
    {
        if (!dicListeners.ContainsKey(type))
        {
            dicListeners.Add(type, new List<IObserverListener>());
        }
        if (!dicListeners[type].Contains(listener))
        {
            dicListeners[type].Add(listener);
        }

    }

    public void UnregisterEvent(EventType type, IObserverListener listener)
    {
        if (dicListeners.ContainsKey(type) && dicListeners[type].Contains(listener))
        {
            dicListeners[type].Remove(listener);
        }
    }
    public void NotifyEvent(EventType type, object data)
    {
        if (!dicListeners.ContainsKey(type)) return;
        foreach (IObserverListener listener in dicListeners[type])
        {
            listener.NotifyEvent(type, data);
        }
    }
}
