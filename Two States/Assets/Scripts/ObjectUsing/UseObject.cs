using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObject : MonoBehaviour
{
    [SerializeField] private PickableObject hand;
    public PickableObject Hand { get => hand; }

    [HideInInspector] [SerializeField] private PickableObject pickedObject;
    public PickableObject PickedObject { get => pickedObject; }


    [Space(20)]
    [SerializeField] private float useDelay = 1.0f;
    [Tooltip("Starting point and direction for raycasting.")]
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance = 5f;
    [Tooltip("Anything ray can hit. Including usable and blocking objects.")]
    [SerializeField] private LayerMask rayMask = 32768; //should include layer 15 automatically. Layer 15 should be "UsableObject"
    [Tooltip("Only for the UsableObject layer.")]
    [SerializeField] private int usableMask = 15; //should include layer 15 automatically. Layer 15 should be "UsableObject"

    private void OnValidate()
    {
        if (pickedObject == null && hand != null) { pickedObject = hand; }
    }


    private float delayTimer = 0.0f;
    private void Update()
    {
        if (delayTimer > 0.0f)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0.0f) { TryUse(); }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && delayTimer <= 0.0f)
        {
            delayTimer = useDelay;
            PickedObject.OnEvents.Invoke(OnEventType.OnTryUse, this);
            if (PickedObject != Hand) { Hand.OnEvents.Invoke(OnEventType.OnTryUse, this); }
        }

    }

    private void TryUse()
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hit, rayDistance, rayMask);
        Debug.DrawRay(rayPoint.position, rayPoint.TransformDirection(Vector3.forward) * rayDistance, Color.red, 1f);

        //Didn't hit anything
        if (!didHit) { PickedObject.OnEvents.Invoke(OnEventType.OnNoHit, this); return; }
        //Hit something blocking
        if (hit.collider.gameObject.layer != usableMask) { PickedObject.OnEvents.Invoke(OnEventType.OnNoHit, this); return; }

        //Hit something usable
        UsableObject hitObject = hit.collider.GetComponent<UsableObject>();
        if (hitObject == null) { Debug.LogError(string.Format("{0} is missing UsableObject component!", hit.collider.gameObject.name)); return; }

        if (hitObject.Use(this, pickedObject)) { PickedObject.OnEvents.Invoke(OnEventType.OnUse, this); }
        else { PickedObject.OnEvents.Invoke(OnEventType.OnUnusable, this); }
    }

    public void PickObject(PickableObject pickablecObject)
    {
        if (PickedObject != hand) { DropObject(true); }
        pickedObject = pickablecObject;
    }

    public void DropObject(bool replace = false)
    {
        if (pickedObject == Hand) { return; } //invoke ondrop for hand?
        if (pickedObject != null) { PickedObject.Drop(this); }
        if (!replace) { pickedObject = hand; PickedObject.OnEvents.Invoke(OnEventType.OnPickup, this); }
    }
}
