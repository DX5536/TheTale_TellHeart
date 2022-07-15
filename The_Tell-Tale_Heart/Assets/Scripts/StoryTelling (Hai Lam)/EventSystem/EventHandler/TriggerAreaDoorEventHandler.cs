using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaDoorEventHandler : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";

    [Header("Make sure Door open for Policemen too")]
    [SerializeField]
    private string policemanTag = "Policeman";

    [SerializeField]
    private int handlerID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag) || other.gameObject.CompareTag(policemanTag))
        {
            DoorEventManager.DoorwayTriggerEnter(handlerID);
        }
    }

    //Have to add this to avoid Policeman stuck front of Door cuz player too fast
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag) || other.gameObject.CompareTag(policemanTag))
        {
            DoorEventManager.DoorwayTriggerEnter(handlerID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DoorEventManager.DoorTriggerClose(handlerID);
    }
}
