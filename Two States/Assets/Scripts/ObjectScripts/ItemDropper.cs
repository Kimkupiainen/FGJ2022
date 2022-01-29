using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] Collider targetCollider;
    [SerializeField] Rigidbody targetRB;

    private void OnValidate()
    {
        if (targetCollider != null && targetCollider.enabled) { targetCollider.enabled = false; }
        if (targetRB != null && !targetRB.isKinematic) { targetRB.isKinematic = true; }
    }

    public void Drop()
    {
        targetObject.transform.parent = null;
        if (targetCollider != null) { targetCollider.enabled = true; }
        if (targetRB != null) { targetRB.isKinematic = false; }
        Destroy(this.gameObject);
    }
}
