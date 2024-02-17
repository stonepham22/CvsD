using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : LoboMonoBehaviour
{
    [Header("Base Slider")]
    [SerializeField] protected Slider slider;

    protected virtual void Start()
    {
        this.AddOnClickEvent();
        this.DisableSliderInteraction();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }

    protected virtual void AddOnClickEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }

    protected virtual void OnChanged(float newValue)
    {
        this.slider.value = newValue;
    }

    protected virtual void DisableSliderInteraction()
    {
        if (this.slider != null)
        {
            this.slider.interactable = false;
        }
    }

}
