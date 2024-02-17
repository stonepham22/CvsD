using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ContainersDragAndDrop : LoboMonoBehaviour, IDropHandler, IPointerClickHandler
{
    [Header("ContainersDragAndDrop")]
    [SerializeField] protected const string CHICKENS_TAG = "Chickens";
    [SerializeField] protected const string SHIELD_TAG = "Shield";
    [SerializeField] protected const string DOG_TAG = "Dog";

    [SerializeField] protected Image image;
    [SerializeField] protected float alphaDropping = 0.5f;
    [SerializeField] protected float alphaEndDrop = 0;

    protected abstract void SetRealParent(GameObject dropObj);
    protected abstract void ChangeColorImage(GameObject collision);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    protected virtual void FixedUpdate()
    {
        if (transform.childCount == 0) return;
        this.ChangeAlphaImage(this.alphaEndDrop);
    }

    void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage", gameObject);
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0) return;
        GameObject dropObj = eventData.pointerDrag;
        this.SetRealParent(dropObj);
        this.ChangeAlphaImage(this.alphaEndDrop);
    }

    protected virtual void ChangeRedImage()
    {
        Color redColor = Color.red;
        this.image.color = redColor;
    }

    protected virtual void ChangeWhiteImage()
    {
        Color whiteColor = Color.white;
        this.image.color = whiteColor;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(DOG_TAG)) return;
        this.ChangeColorImage(collision.gameObject);
        this.ChangeAlphaImage(this.alphaDropping);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(DOG_TAG)) return;
        this.ChangeColorImage(collision.gameObject);
        this.ChangeWhiteImage();
        this.ChangeAlphaImage(this.alphaEndDrop);
    }

    public void ChangeAlphaImage(float alphaValue)
    {
        //if (transform.childCount > 0) return;
        Color imageColor = image.color;
        imageColor.a = alphaValue;
        image.color = imageColor;
    }

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
