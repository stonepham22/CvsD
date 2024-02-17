using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseListText : LoboMonoBehaviour
{

    [SerializeField] protected List<Text> texts = new List<Text>();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTexts();
    }

    void LoadTexts()
    {
        if (texts.Count > 0) return;

        foreach (Transform transform in transform)
        {
            Text text = transform.GetComponent<Text>();
            if(text == null) continue;
            texts.Add(text);
        }
    }

    public void ShowText(int index, int value)
    {
        this.texts[index].text = value.ToString();
    }

    public void ShowLevel(int index, int level)
    {
        this.texts[index].text = "Level " + level.ToString();
    }

}
