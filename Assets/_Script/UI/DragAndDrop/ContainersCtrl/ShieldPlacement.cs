using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlacement : ContainersDragAndDrop
{
    protected override void ChangeColorImage(GameObject collision)
    {
        if (transform.childCount > 0) return;
        if (collision.CompareTag(SHIELD_TAG)) this.ChangeWhiteImage();
        else if (collision.CompareTag(CHICKENS_TAG)) this.ChangeRedImage();
    }

    protected override void SetRealParent(GameObject dropObj)
    {
        if (dropObj.CompareTag(CHICKENS_TAG)) return;
        ShieldPrefab shieldPrefab = dropObj.GetComponent<ShieldPrefab>();
        shieldPrefab.SetRealParent(transform);
        //shieldPrefab.SetIsDrag(true);
    }

}
