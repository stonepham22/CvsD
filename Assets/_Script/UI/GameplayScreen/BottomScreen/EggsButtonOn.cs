using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsButtonOn : BaseButton
{
    [SerializeField] private bool isSpawnChicken = true;
    protected override void OnClick()
    {
        gameObject.SetActive(false);
        if(this.isSpawnChicken)
        {
            this.isSpawnChicken = false;
            this.SpawnChicken();
        }
        else
        {
            this.isSpawnChicken = true;
            this.SpawnShield();
        }
    }

    void SpawnChicken()
    {
        UISpawnerCtrl uISpawnerCtrl = this.GetUISpawnerCtrl();
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ChickenSpawner.ChickenSpawnInLobbyFromEgg();
    }

    void SpawnShield()
    {
        UISpawnerCtrl uISpawnerCtrl = this.GetUISpawnerCtrl();
        uISpawnerCtrl.ShieldSpawner.ShieldSpawning();
    }

    UISpawnerCtrl GetUISpawnerCtrl()
    {
        return UICtrl.Instance.DragAndDrop.UISpawnerCtrl;
    }    

}
