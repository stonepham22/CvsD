using UnityEngine;

public class ItemButtonData
{
    public GameObject itemPrefab;
    public int itemPricePrev;
    public int itemPriceCur;
    public int itemLevel;

    public GetPlayerLevelDelegate getPlayerLevelDelegate;
    public GetPlayerCoinDelegate getPlayerCoinDelegate;
}