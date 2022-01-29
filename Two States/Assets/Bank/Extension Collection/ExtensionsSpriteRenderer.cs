using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsSpriteRenderer
{
    /// <summary>
    /// Makes sprites to overlap correctly on Y-axis
    /// </summary>
    public static void SetVerticalSpriteOrder(this SpriteRenderer rend, float unitMultiply = 10f)
    {
        rend.sortingOrder = Mathf.RoundToInt(rend.transform.position.y * -unitMultiply);
    }
}
