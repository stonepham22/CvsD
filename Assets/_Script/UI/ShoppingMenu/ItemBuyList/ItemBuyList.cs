using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuyList : LoboMonoBehaviour
{

    [SerializeField] private ItemLevel _itemLevel;
    [SerializeField] private ButtonMax _buttonMax;
    [SerializeField] private ButtonOff _buttonOff;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemLevel();
        this.LoadButtonMax();
        this.LoadButtonOff();
    }

    void LoadItemLevel()
    {
        if (this._itemLevel != null) return;
        this._itemLevel = GetComponentInChildren<ItemLevel>();
        Debug.LogWarning(transform.name + ": LoadItemLevel", gameObject);
    }

    void LoadButtonMax()
    {
        if (this._buttonMax != null) return;
        this._buttonMax = GetComponentInChildren<ButtonMax>();
        Debug.LogWarning(transform.name + ": LoadButtonMax", gameObject);
    }

    void LoadButtonOff()
    {
        if (this._buttonOff != null) return;
        this._buttonOff = GetComponentInChildren<ButtonOff>();
        Debug.LogWarning(transform.name + ": LoadButtonOff", gameObject);
    }

    public void ShowLevel(int index, int level)
    {
        this._itemLevel.ShowLevel(index, level);
    }    

    public void OnEnableButtonOff(int index)
    {
        this._buttonOff.OnEnableTranform(index);
    }

    public void OnEnableButtonMax(int index)
    {
        this._buttonMax.OnEnableTranform(index);
    }

}
