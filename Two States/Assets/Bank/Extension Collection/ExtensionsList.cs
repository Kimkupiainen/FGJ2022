using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsList
{
    public static void AddIfNotNull<T>(this IList<T> list, T item, int toIndex = -1)
    {
        if (item == null) { return; }
        if (toIndex < 0) { list.Add(item); }
        else { list.Insert(toIndex, item); }
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static int OutOfListId<T>(this IList<T> list, int id)
    {
        if (id >= list.Count) { return 0; }
        return id;
    }

    //Does anything=??????????????????????????????????????????????????????????????
    public static void SortByName<T>(this List<T> list) where T : UnityEngine.Object
    {
        System.Array.Sort(list.ToArray(), (a, b) => a.name.CompareTo(b.name));
    }

    /// <summary>
    /// Invokes action once per object in the list using the object as a parameter. From last to first.
    /// </summary>
    /// <param name="list">List of parameters</param>
    /// <param name="action">Action to be invoked</param>
    public static void InvokeEach<T>(this List<T> list, Action<T> action)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            action.Invoke(list[i]);
        }
    }
}