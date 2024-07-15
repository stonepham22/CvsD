public enum EventType
{
    DogOnDead, DogTriggerEnter, DogTriggerExit,

    BulletDespawn, BulletCollideWithDog,

    NextWave, ShowWaveText,
    
    ShowExp,
    LevelUp, ShowLevel,

    IncreaseCoin,  DecreaseCoin, ShowCoin,
   
    BuyChicken, ChickenShooting, ChickenOnDead,

    DisableChickenButtonOn,

    OnClickShoppingButtonOn, DisableShoppingMenu,
    EnableShoppingMenuItemButton,  OnClickShoppingMenuItemButton, 
    ItemLevelGatherThanPlayerLevel, ItemCoinGatherThanPlayerCoin,
    ExitShoppingMenu,

    ShieldOnEnable, ShieldRepaired, ShieldUpgraded,

}