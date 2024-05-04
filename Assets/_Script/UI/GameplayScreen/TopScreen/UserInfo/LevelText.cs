using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : BaseText
{

    [SerializeField] private int _level = 1;

    private void Start()
    {
        this.LoadLevel();
        this.ShowLevel();
    }

    private void LoadLevel()
    {
        
    }

    private void ShowLevel()
    {
        this.text.text = this._level.ToString();
    }


    public void LevelUp()
    {
        this._level++;
        this.ShowLevel();
        UICtrl.Instance.GameplayScreen.TopScreen.LevelExp.ShowExpSlider(0);
    }

    

}
