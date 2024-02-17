using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyButton : BaseShoppingButton
{

    protected override void ResetValue()
    {
        base.ResetValue();
        this.index = 3;
    }

}
