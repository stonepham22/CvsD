using UnityEngine;

public abstract class BaseSingleton<T> : LoboMonoBehaviour where T : BaseSingleton<T>
{
    
    private static T _instance;
    public static T Instance => _instance;

    protected override void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this as T;
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
