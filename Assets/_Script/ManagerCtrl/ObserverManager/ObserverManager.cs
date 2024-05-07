using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : BaseSingleton<ObserverManager>
{
    public Dictionary<EventType, List<IObserverListener>> dicListeners = new Dictionary<EventType, List<IObserverListener>>();

    public void RegisterEvent(EventType type, IObserverListener listener)
    {
        if(!dicListeners.ContainsKey(type)) dicListeners.Add(type, new List<IObserverListener>());
        dicListeners[type].Add(listener);
    }

    public void NotifyEvent(EventType type, object data)
    {
        if(!dicListeners.ContainsKey(type)) dicListeners.Add(type, new List<IObserverListener>());
        foreach(IObserverListener listener in dicListeners[type])
        {
            listener.NotifyEvent(data);
        }
    }

}
