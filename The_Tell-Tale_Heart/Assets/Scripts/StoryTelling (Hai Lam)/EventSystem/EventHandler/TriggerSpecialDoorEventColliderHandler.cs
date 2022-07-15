using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpecialDoorEventColliderHandler : MonoBehaviour
{
    [SerializeField]
    private int handlerColliderID;

    public void SpecialTriggerTurnOnCollider()
    {
        EventsEventManager.ColliderEventTriggerActivate(handlerColliderID);
    }
}
