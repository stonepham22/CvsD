using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainersCtrl : LoboMonoBehaviour
{

    [SerializeField] private LobbyCtrl _lobbyCtrl;
    public LobbyCtrl LobbyCtrl => _lobbyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLobbyCtrl();
    }

    void LoadLobbyCtrl()
    {
        if (this._lobbyCtrl != null) return;
        this._lobbyCtrl = GetComponentInChildren<LobbyCtrl>();
        Debug.LogWarning(transform.name + ": LoadLobbyCtrl", gameObject);
    }

}
