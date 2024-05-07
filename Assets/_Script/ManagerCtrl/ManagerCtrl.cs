using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCtrl : BaseSingleton<ManagerCtrl>
{

    [SerializeField] private InputManager _inputManager;
    public InputManager InputManager => _inputManager;

    [SerializeField] private PlayerPrefsManager _playerPrefs;
    public PlayerPrefsManager PlayerPrefs => _playerPrefs;

    [SerializeField] private PlayerManager _playerManager;
    public PlayerManager PlayerManager => _playerManager;

    [SerializeField] private WaveManager _wave;
    public WaveManager Wave => _wave;

    [SerializeField] private PoolManager _pool;
    public PoolManager Pool => _pool;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInputManager();
        this.LoadPlayerPrefsManager();
        this.LoadPlayerManager();
        this.LoadWaveManager();
        this.LoadPoolManager();
    }

    private void LoadInputManager()
    {
        if (this._inputManager != null) return;
        this._inputManager = GetComponentInChildren<InputManager>();
        Debug.LogWarning(transform.name + ": LoadInputManager", gameObject);
    }

    private void LoadPlayerPrefsManager()
    {
        if (this._playerPrefs != null) return;
        this._playerPrefs = GetComponentInChildren<PlayerPrefsManager>();
        Debug.LogWarning(transform.name + ": LoadPlayerPrefsManager", gameObject);
    }

    private void LoadPlayerManager()
    {
        if (this._playerManager != null) return;
        this._playerManager = GetComponentInChildren<PlayerManager>();
        Debug.LogWarning(transform.name + ": LoadPlayerManager", gameObject);
    }

    private void LoadWaveManager()
    {
        if (this._wave != null) return;
        this._wave = GetComponentInChildren<WaveManager>();
        Debug.LogWarning(transform.name + ": LoadWaveManager", gameObject);
    }

    private void LoadPoolManager()
    {
        if (this._pool != null) return;
        this._pool = GetComponentInChildren<PoolManager>();
        Debug.LogWarning(transform.name + ": LoadPoolManager", gameObject);
    }

}
