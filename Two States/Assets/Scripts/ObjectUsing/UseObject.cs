using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObject : MonoBehaviour
{
    [SerializeField] private PickableObject hand;

    [HideInInspector] [SerializeField] private PickableObject pickedObject;
    public PickableObject PickedObject { get => pickedObject; }


    [Space(20)]
    [Tooltip("Starting point and direction for raycasting.")]
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance = 5f;
    [Tooltip("Anything ray can hit. Including usable and blocking objects.")]
    [SerializeField] private LayerMask rayMask = 32768; //should include layer 15 automatically. Layer 15 should be "UsableObject"
    [Tooltip("Only for the UsableObject layer.")]
    [SerializeField] private LayerMask usableMask = 32768; //should include layer 15 automatically. Layer 15 should be "UsableObject"

    private void OnValidate()
    {
        if (pickedObject == null && hand != null) { pickedObject = hand; }
    }

    private void TryUse()
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hit, rayDistance, rayMask);

        //Didn't hit anything
        if (!didHit) { PickedObject.OnNoHit.Invoke(); return; }
        //Hit something blocking
        if (hit.collider.gameObject.layer != usableMask) { PickedObject.OnNoHit.Invoke(); return; }

        //Hit something usable
        UsableObject hitObject = hit.collider.GetComponent<UsableObject>();
        if (hitObject == null) { Debug.LogError(string.Format("{0} is missing UsableObject component!", hit.collider.gameObject.name)); return; }

        if (hitObject.Use(this, pickedObject)) { PickedObject.OnUse.Invoke(); }
        else { PickedObject.OnUnusable.Invoke(); }
    }

    public void PickObject(PickableObject pickablecObject)
    {
        if (PickedObject != hand) { DropObject(true); }
        pickedObject = pickablecObject;
        PickedObject.OnPickup.Invoke(this);
    }

    public void DropObject(bool replace = false)
    {
        if (pickedObject != null) { PickedObject.OnDrop.Invoke(this); }
        if (!replace) { pickedObject = hand; PickedObject.OnPickup.Invoke(this); }
    }
}
