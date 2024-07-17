using UnityEngine;

public class Lobby : ContainersDragAndDrop
{
    
    protected override void ChangeColorImage(GameObject collision)
    {
        if (transform.childCount > 0) return;
        this.ChangeWhiteImage();
    }

    protected override void SetRealParent(GameObject dropObj)
    {
        ObjectDragAndDrop objectDragAndDrop = dropObj.GetComponent<ObjectDragAndDrop>();
        objectDragAndDrop.SetRealParent(transform);
    }
}
