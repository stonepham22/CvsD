using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : BaseText
{
    
    public void ShowLevel(int level)
    {
        this.text.text = level.ToString();
    }

}
