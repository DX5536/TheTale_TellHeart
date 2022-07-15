using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsEventManager : MonoBehaviour
{
    //Activate (SetAvtive) collider event
    public static event Action<int> onColliderEventTriggerActivate;
    public static void ColliderEventTriggerActivate(int colliderID)
    {
        if (onColliderEventTriggerActivate != null)
        {
            //Debug.Log("Event Turn ON collider EVENT is registered");
            onColliderEventTriggerActivate(colliderID);
        }
    }

    //Deactivate collider event
    public static event Action<int> onColliderEventTriggerDeactivate;
    public static void ColliderEventTriggerDeactivate(int colliderID)
    {
        if (onColliderEventTriggerActivate != null)
        {
            //Debug.Log("Event Turn off collider EVENT is registered");
            onColliderEventTriggerDeactivate(colliderID);
        }
    }
}
