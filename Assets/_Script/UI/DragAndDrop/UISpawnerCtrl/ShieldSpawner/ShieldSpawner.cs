using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawner : Spawner
{

    [SerializeField] private Transform _parent;

    public void ShieldSpawning()
    {
        this._parent = UICtrl.Instance.DragAndDrop.ContainersCtrl.LobbyCtrl.CheckLobbyEmpty();
        if (this._parent == null) return;
        GameObject prefab = this.RandomPrefab();
        Vector3 spawnPos = transform.position;
        GameObject obj = this.Spawn(prefab, spawnPos, Quaternion.identity);
        obj.SetActive(true);
    }

    protected override void SetParentNewPrefab(GameObject newPrefab)
    {
        newPrefab.transform.SetParent(this._parent, false);
    }

    public void DontUpgradeShield()
    {
        this.SetFalseIsSelectedAllShieldPrefab();
        this.OnEnableShieldUpgradeButtonOff();
    }

    public void SetFalseIsSelectedAllShieldPrefab()
    {
        ShieldPrefab[] allShields = FindObjectsOfType<ShieldPrefab>();
        foreach (ShieldPrefab shield in allShields)
        {
            shield.SetFalseIsSelected();
        }
    }

    public void OnEnableShieldUpgradeButtonOff()
    {
        UICtrl.Instance.GameplayScreen.BottomScreen.ShieldUpgrade.ButtonOff.gameObject.SetActive(true);
    }

}
