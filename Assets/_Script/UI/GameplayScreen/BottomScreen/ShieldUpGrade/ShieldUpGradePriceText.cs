using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpGradePriceText : BaseText
{
   
    public void ShowUpGradePrice(int price)
    {
        this.text.text = price.ToString();
    }

}
