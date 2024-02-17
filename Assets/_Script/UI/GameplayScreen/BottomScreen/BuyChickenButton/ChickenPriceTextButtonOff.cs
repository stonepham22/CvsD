using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPriceTextButtonOff : BaseText
{
    
    public void ShowChickenPrice(int price)
    {
        this.text.text = price.ToString();
    }    

}
