using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsBool
{
    public static int ToInt(this bool value)
    {
        return Convert.ToInt32(value);
    }
}
