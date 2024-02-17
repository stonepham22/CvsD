using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Background : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        this.UnClickShieldPrefab();
        this.UnClickChickenPrefab();
    }

    private void UnClickShieldPrefab()
    {
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ShieldSpawner.DontUpgradeShield();
        UICtrl.Instance.GameplayScreen.BottomScreen.ShieldRepair.ButtonOff.gameObject.SetActive(true);
    }

    private void UnClickChickenPrefab()
    {
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ChickenSpawner.SetFalseIsSelectedAllChickenPrefab();
    }

}
