using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCtrl : LoboMonoBehaviour
{

    private static ManagerCtrl _instance;
    public static ManagerCtrl Instance => _instance;

    [SerializeField] private InputManager _inputManager;
    public InputManager InputManager => _inputManager;

    [SerializeField] private PlayerPrefsManager _playerPrefs;
    public PlayerPrefsManager PlayerPrefs => _playerPrefs;

    [SerializeField] private PlayerManager _playerManager;
    public PlayerManager PlayerManager => _playerManager;

    protected override void Awake()
    {
        if (ManagerCtrl._instance != null) Debug.LogError("only 1 ManagerCtrl allow to exist");
        ManagerCtrl._instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInputManager();
        this.LoadPlayerPrefsManager();
        this.LoadPlayerManager();
    }

    void LoadInputManager()
    {
        if (this._inputManager != null) return;
        this._inputManager = GetComponentInChildren<InputManager>();
        Debug.LogWarning(transform.name + ": LoadInputManager", gameObject);
    }

    void LoadPlayerPrefsManager()
    {
        if (this._playerPrefs != null) return;
        this._playerPrefs = GetComponentInChildren<PlayerPrefsManager>();
        Debug.LogWarning(transform.name + ": LoadPlayerPrefsManager", gameObject);
    }

    void LoadPlayerManager()
    {
        if (this._playerManager != null) return;
        this._playerManager = GetComponentInChildren<PlayerManager>();
        Debug.LogWarning(transform.name + ": LoadPlayerManager", gameObject);
    }

}
