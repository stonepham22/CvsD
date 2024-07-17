using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LazySingleton<T> : LoboMonoBehaviour where T : LazySingleton<T>
{
    protected static T instance;
    private static object _lock = new object();
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                return null;
            }
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        var obj = new GameObject(typeof(T).ToString());
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
    }
    protected virtual void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    protected virtual void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }
}
