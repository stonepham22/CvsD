using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : LoboMonoBehaviour
{

    [SerializeField] private PlayerLevel _playerLevel;
    public PlayerLevel PlayerLevel => _playerLevel;

    [SerializeField] private PlayerCoin _playerCoin;
    public PlayerCoin PlayerCoin => _playerCoin;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerLevel();
        this.LoadPlayerCoin();
    }

    private void LoadPlayerLevel()
    {
        if (this._playerLevel != null) return;
        this._playerLevel = GetComponentInChildren<PlayerLevel>();
        Debug.LogWarning(transform.name + ": LoadPlayerLevel", gameObject);
    }

    private void LoadPlayerCoin()
    {
        if (this._playerCoin != null) return;
        this._playerCoin = GetComponentInChildren<PlayerCoin>();
        Debug.LogWarning(transform.name + ": LoadPlayerCoin", gameObject);
    }

}
