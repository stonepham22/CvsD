using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseSingleton<PlayerManager>
{

    [SerializeField] private PlayerCoin _playerCoin;
    public PlayerCoin PlayerCoin => _playerCoin;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCoin();
    }

    private void LoadPlayerCoin()
    {
        if (this._playerCoin != null) return;
        this._playerCoin = GetComponentInChildren<PlayerCoin>();
        Debug.LogWarning(transform.name + ": LoadPlayerCoin", gameObject);
    }

}
