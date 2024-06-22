using UnityEngine;

public abstract class BaseSingleton<T> : LoboMonoBehaviour where T : BaseSingleton<T>
{

    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
                if (_instance == null)
                {
                    var obj = new GameObject(typeof(T).ToString());
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected override void Awake()
    {
        if (_instance == null)
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
