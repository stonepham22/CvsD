using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScreen : LoboMonoBehaviour, IObserverListener
{

    [SerializeField] private TopScreen _topScreen;
    public TopScreen TopScreen => _topScreen;

    [SerializeField] private BottomScreen _bottomScreen;
    public BottomScreen BottomScreen => _bottomScreen;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTopScreen();
        this.LoadBottomScreen();
    }

    void LoadTopScreen()
    {
        if (this._topScreen != null) return;
        this._topScreen = GetComponentInChildren<TopScreen>();
        Debug.LogWarning(transform.name + ": LoadTopScreen", gameObject);
    }

    void LoadBottomScreen()
    {
        if (this._bottomScreen != null) return;
        this._bottomScreen = GetComponentInChildren<BottomScreen>();
        Debug.LogWarning(transform.name + ": LoadBottomScreen", gameObject);
    }

    private void Start()
    {
        this.RegisterEvent();
    }

    private void RegisterEvent()
    {
        ObserverManager.Instance.RegistEvent(EventType.OnClickShoppingButtonOn, this);
        ObserverManager.Instance.RegistEvent(EventType.OnClickExitShoppingMenuButton, this);
    }
    public void NotifyEvent(EventType type, object data)
    {
        if(type == EventType.OnClickShoppingButtonOn) transform.gameObject.SetActive(false);
        else transform.gameObject.SetActive(true);
    }

}
