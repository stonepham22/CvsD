using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSlider : BaseSlider
{
    
    public void ShowShieldSlider(float newValue)
    {
        this.OnChanged(newValue);
    }

}
