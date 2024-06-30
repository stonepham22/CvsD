using UnityEngine;

public abstract class BaseSingleton<T> : LoboMonoBehaviour where T : BaseSingleton<T>
{
    private static T _instance;
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
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        var obj = new GameObject(typeof(T).ToString());
                        _instance = obj.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }
    }

    protected override void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
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