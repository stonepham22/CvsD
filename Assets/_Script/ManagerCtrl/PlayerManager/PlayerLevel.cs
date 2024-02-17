using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerLevel : BasePlayerManager
{

    [SerializeField] private int _level = 1;

    private void Start()
    {
        this.LoadLevel();
        this.ShowLevel();
    }

    void LoadLevel()
    {
            
    }    

    void ShowLevel()
    {
        UICtrl.Instance.GameplayScreen.TopScreen.LevelText.ShowLevel(this._level);
    }    

    public void LevelUp()
    {
        this._level++;
        UICtrl.Instance.GameplayScreen.TopScreen.LevelText.ShowLevel(this._level);
        UICtrl.Instance.GameplayScreen.TopScreen.LevelExp.ShowExpSlider(0);
    }    

    public int GetLevel()
    {
        return this._level;
    }

}
