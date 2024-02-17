using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinText : BaseText
{
    
    public void ShowCoin(int coin)
    {
        this.text.text = coin.ToString();
    }

}
