using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(BoxCollider2D))]

public abstract class ObjectDragAndDrop : LoboMonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [Header("Object Drag And Drop")]
    [SerializeField] protected CanvasGroup canvasGroup;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected Transform realParent;
    [SerializeField] protected bool isCanDrag = true;
    [SerializeField] protected bool isSelected = false;
    public bool IsSelected => isSelected;

    public void SetRealParent(Transform realParent)

    {
        this.realParent = realParent;
    }

    protected void OnEnable()
    {
        this.isCanDrag = true;
    }
    protected override void LoadComponents()
    {
        this.LoadCanvasGroup();
        this.LoadBoxCollider2D();
    }

    void LoadCanvasGroup()
    {
        if (this.canvasGroup != null) return;
        this.canvasGroup = GetComponent<CanvasGroup>();
        Debug.LogWarning(transform.name + ": LoadCanvasGroup", gameObject);
    }

    void LoadBoxCollider2D()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = GetComponent<BoxCollider2D>();
        Debug.LogWarning(transform.name + ": LoadBoxCollider2D", gameObject);
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if(!this.isCanDrag) return;
        this.canvasGroup.alpha = .6f;
        this.canvasGroup.blocksRaycasts = false;
        this.realParent = transform.parent;
        Transform containersCtrl = UICtrl.Instance.DragAndDrop.ContainersCtrl.transform;
        transform.SetParent(containersCtrl);
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (!this.isCanDrag) return;
        this.ObjMoveByMouse();
        this.boxCollider2D.enabled = true;
    }

    void ObjMoveByMouse()
    {
        Vector3 mousePos = this.GetMousePos();
        mousePos.z = 0;
        transform.position = mousePos;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (!this.isCanDrag) return;
        this.canvasGroup.alpha = 1f;
        this.canvasGroup.blocksRaycasts = true;
        transform.SetParent(this.realParent);
        this.CheckIsCanDrag();
    }

    protected abstract void CheckIsCanDrag();

    Vector3 GetMousePos()
    {
        return ManagerCtrl.Instance.InputManager.MouseWorldPos;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        this.SetFalseIsSelectedAllPrefab();
        this.isSelected = true;
        this.SetActiveRemoveButtonOn(true);
    }

    public virtual void SetFalseIsSelected()
    {
        this.isSelected = false;
        this.SetActiveRemoveButtonOn(false);
    }

    protected virtual void SetActiveRemoveButtonOn(bool active)
    {
        UICtrl.Instance.GameplayScreen.BottomScreen.RemoveButtonOn.gameObject.SetActive(active);
    }

    public virtual void SetFalseIsSelectedAllPrefab()
    {
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ChickenSpawner.SetFalseIsSelectedAllChickenPrefab();
        UICtrl.Instance.DragAndDrop.UISpawnerCtrl.ShieldSpawner.SetFalseIsSelectedAllShieldPrefab();
    }

}
