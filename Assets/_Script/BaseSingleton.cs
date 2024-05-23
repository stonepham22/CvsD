using UnityEngine;

public abstract class BaseSingleton<T> : LoboMonoBehaviour where T : BaseSingleton<T>
{
    
    private static volatile T _instance;
    private static readonly object _lockObject = new object();
    public static T Instance
    {
        get 
        {
            if (_instance == null)
            {
                lock (_lockObject)
                {
                    _instance = GameObject.FindObjectOfType(typeof(T)) as T;
                    if (_instance == null)
                    {
                        var obj = new GameObject(typeof(T).ToString());
                        _instance = obj.AddComponent<T>();
                    }
                }    
            }
            return _instance; 
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
