using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCtrl : LoboMonoBehaviour
{
    
    [SerializeField] private List<Transform> lobbys = new List<Transform>();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLobbys();
    }

    void LoadLobbys()
    {
        if (this.lobbys.Count > 0) return;
        
        foreach(Transform lobby in transform)
        {
            this.lobbys.Add(lobby); 
        }
    }    

    public Transform CheckLobbyEmpty()
    {
        foreach(Transform lobby in this.lobbys)
        {
            if (lobby.childCount > 0) continue;
            return lobby;
        }

        return null;
    }    

}
