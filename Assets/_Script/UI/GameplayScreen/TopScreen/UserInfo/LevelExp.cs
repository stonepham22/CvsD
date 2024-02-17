using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExp : BaseSlider
{
    
    public void ShowExpSlider(float newValue)
    {
        this.OnChanged(newValue);
    }
    
}
