using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : BaseSingleton<WaveManager>, IObserverListener
{
    [Header("Wave Manager")]

    [SerializeField] private int _currentWave = 1;
    public int CurrentWave => _currentWave;
    [SerializeField] private int _totalWave = 7;
    [SerializeField] private int _spawnCountLimiteInWave = 10;

    private void Start()
    {
        ObserverManager.Instance.RegistEvent(EventType.NextWave, this);
    }

    public void NotifyEvent(EventType type, object data)
    {
        this.NextWave();
    }

    public int GetSpawnCountLimiteInWave()
    {
        return _spawnCountLimiteInWave;
    }    

    private void NextWave()
    {
        if (_currentWave == _totalWave) this.WinGame();
        else this.UpdateNewWave();
    }

    private void UpdateNewWave()
    {
        this._currentWave++;
        this._spawnCountLimiteInWave *= 2;
        this.ShowWaveText();
    }

    private void ShowWaveText()
    {
        ObserverManager.Instance.NotifyEvent(EventType.ShowWaveText, this._currentWave);
    }

    private void WinGame()
    {
        Debug.Log("WinGame");
    }

}
