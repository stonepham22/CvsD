using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : LoboMonoBehaviour
{

    [SerializeField] private PlayerExperience _playerExperience;
    public PlayerExperience PlayerExperience => _playerExperience;

    [SerializeField] private PlayerLevel _playerLevel;
    public PlayerLevel PlayerLevel => _playerLevel;

    [SerializeField] private PlayerCoin _playerCoin;
    public PlayerCoin PlayerCoin => _playerCoin;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerExperience();
        this.LoadPlayerLevel();
        this.LoadPlayerCoin();
    }

    void LoadPlayerExperience()
    {
        if (this._playerExperience != null) return;
        this._playerExperience = GetComponentInChildren<PlayerExperience>();
        Debug.LogWarning(transform.name + ": LoadPlayerExperience", gameObject);
    }

    void LoadPlayerLevel()
    {
        if (this._playerLevel != null) return;
        this._playerLevel = GetComponentInChildren<PlayerLevel>();
        Debug.LogWarning(transform.name + ": LoadPlayerLevel", gameObject);
    }

    void LoadPlayerCoin()
    {
        if (this._playerCoin != null) return;
        this._playerCoin = GetComponentInChildren<PlayerCoin>();
        Debug.LogWarning(transform.name + ": LoadPlayerCoin", gameObject);
    }

}
