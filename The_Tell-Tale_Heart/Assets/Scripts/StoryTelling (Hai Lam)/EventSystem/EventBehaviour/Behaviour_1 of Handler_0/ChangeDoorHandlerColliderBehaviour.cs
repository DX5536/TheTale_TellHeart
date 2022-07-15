using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDoorHandlerColliderBehaviour : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] doorHandlerEventColliders;

    [SerializeField]
    private GameObject myDoorColliderHandler;

    [SerializeField]
    private int colliderID;


    private void OnEnable()
    {
        //Like & Subscribe
        EventsEventManager.onColliderEventTriggerActivate += ActivateColliders;
        EventsEventManager.onColliderEventTriggerDeactivate += DeactivateColliders;
    }

    private void OnDisable()
    {
        //Dislike & Unsubscribe
        EventsEventManager.onColliderEventTriggerActivate -= ActivateColliders;
        EventsEventManager.onColliderEventTriggerDeactivate -= DeactivateColliders;
    }

    private void ActivateColliders(int colliderID)
    {
        if(colliderID == this.colliderID)
        {
            myDoorColliderHandler.SetActive(true);
        }
    }

    private void DeactivateColliders(int colliderID)
    {
        if(colliderID == this.colliderID)
        {
            myDoorColliderHandler.SetActive(false);
        }
    }
}
