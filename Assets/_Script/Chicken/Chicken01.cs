using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken01 : MonoBehaviour, IChicken
{
    public void Shoot()
    {
        Debug.Log(transform.name + "Shoot");
    }

}
