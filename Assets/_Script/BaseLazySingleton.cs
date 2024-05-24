using UnityEngine;

public abstract class BaseLazySingleton<T> : LoboMonoBehaviour where T : BaseLazySingleton<T>
{
    
    private static T _instance;
    private static readonly object _lockObject = new object();
    public static T Instance
    {
        get 
        {
            if (_instance == null)
            {
                lock (_lockObject)
                {
                    if( _instance == null)
                    {
                        _instance = GameObject.FindObjectOfType<T>();
                        if (_instance == null)
                        {
                            var obj = new GameObject(typeof(T).ToString());
                            _instance = obj.AddComponent<T>();
                        }
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
