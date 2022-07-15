using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TriggerAreaDoorEventCollidersHandler : MonoBehaviour
{
    [SerializeField]
    private string player;

    [SerializeField]
    private int handlerColliderID;

    private void Start()
    {
        //When game start turn off all DoorColliders
        EventsEventManager.ColliderEventTriggerDeactivate(handlerColliderID);
    }


    private void OnTriggerEnter(Collider other)
    {
        //Player front OldM door -> Go back to living room
        if (other.gameObject.CompareTag(player))
{
            EventsEventManager.ColliderEventTriggerActivate(handlerColliderID);
            
        }
        //Debug.Log(other + "enters me");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            //When player exit -> Deactivate this collider to avoid double whammy
            this.gameObject.SetActive(false);
        }
    }
}
