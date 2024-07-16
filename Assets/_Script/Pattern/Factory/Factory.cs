using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : LoboMonoBehaviour
{
    // Abstract method to get a product instance.
    public abstract IProduct GetProduct(Vector3 position, int id);

    // Shared method with all factories.
}
