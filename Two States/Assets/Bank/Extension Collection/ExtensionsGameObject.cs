using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsGameObject
{
    public static bool IsOnLayerMask(this GameObject go, LayerMask mask)
    {
        if (((1 << go.layer) & mask.value) == (1 << go.layer)) { return true; }
        return false;
    }
}
