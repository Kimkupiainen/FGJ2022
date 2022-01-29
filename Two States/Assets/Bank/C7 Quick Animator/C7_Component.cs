using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public abstract class C7_Component : MonoBehaviour
{
    public virtual void Awake() { }
    /// <summary>
    /// Updates the value of the variable at the linked component based on the given state value.
    /// </summary>
    /// <param name="state">State from 0.0f to 1.0f</param>
    public abstract void UpdateState(float state);

    [EasyButtons.Button()]
    public void AddPlayer()
    {
        C7_Player player = GetComponent<C7_Player>();
        if (player == null)
        {
            gameObject.AddComponent(typeof(C7_Player));
            player = GetComponent<C7_Player>();
            player.LinkedComponents.Add(this);
        }
        else
        {
            for (int i = 0; i < player.LinkedComponents.Count; i++)
            { if (player.LinkedComponents[i] == this) { return; } }
            player.LinkedComponents.Add(this);
        }
    }
}