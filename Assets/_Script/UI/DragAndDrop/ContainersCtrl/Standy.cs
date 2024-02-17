using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class Standy : ContainersDragAndDrop
{

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        GameObject dropObj = eventData.pointerDrag;
        this.SetIndexStandy(dropObj);
    }

    void SetIndexStandy(GameObject dropObj)
    {
        if (!dropObj.CompareTag(CHICKENS_TAG)) return;
        string standyName = transform.gameObject.name;
        char indexChar = standyName[standyName.Length - 1];
        int indexStandy = int.Parse(indexChar.ToString());
        ChickenShooting chickenShooting = dropObj.GetComponentInChildren<ChickenShooting>();
        //chickenShooting.SetIndexStandy(indexStandy);
    }

    protected override void ChangeColorImage(GameObject collision)
    {
        if(collision.CompareTag(CHICKENS_TAG)) this.ChangeWhiteImage();
        if(collision.CompareTag(SHIELD_TAG)) this.ChangeRedImage();
    }

    protected override void SetRealParent(GameObject dropObj)
    {
        if (dropObj.CompareTag(SHIELD_TAG)) return;
        ChickenPrefab chickenPrefab = dropObj.GetComponent<ChickenPrefab>();
        chickenPrefab.SetRealParent(transform);
    }
}
