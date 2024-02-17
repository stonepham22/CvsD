using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPriceText : BaseText
{

    public void ShowRepairPrice(int price)
    {
        this.text.text = price.ToString();
    }

}
