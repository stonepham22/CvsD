using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageButton : BaseShoppingButton
{

    protected override void ResetValue()
    {
        base.ResetValue();
        this.index = 0;
    }

}
