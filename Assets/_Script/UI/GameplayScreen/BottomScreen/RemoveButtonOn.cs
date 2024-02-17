using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveButtonOn : BaseButton
{
    
    protected override void OnClick()
    {
        this.CheckShieldPrefab();
    }

    private void CheckShieldPrefab()
    {
        ShieldPrefab[] allShields = FindObjectsOfType<ShieldPrefab>();
        foreach (ShieldPrefab shield in allShields)
        {
            if (!shield.IsSelected) continue;
            shield.Despawn.Despawning();
            return;
        }
        this.CheckChickenPrefab();
    }

    private void CheckChickenPrefab()
    {
        ChickenPrefab[] allChickens = FindObjectsOfType<ChickenPrefab>();
        foreach (ChickenPrefab chicken in allChickens)
        {
            if (!chicken.IsSelected) continue;
            chicken.Despawn.Despawning();
        }
    }

}
