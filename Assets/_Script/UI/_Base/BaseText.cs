using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseText : LoboMonoBehaviour
{
    [SerializeField] protected Text text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponent<Text>();
        Debug.LogWarning(transform.name + ": LoadText", gameObject);
    }

}