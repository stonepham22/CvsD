using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserverListener
{
    public void NotifyEvent(EventType type ,object data);
}
