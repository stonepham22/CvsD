using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]

public class ShootableObjectSO : ScriptableObject
{
    
    public string objName = "Shootable Object";
    public ObjectType objType;
    public string chickenName;
    public int health;
    public int attackPower;

}
