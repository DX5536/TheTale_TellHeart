using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class ChangeDoorBehaviour : MonoBehaviour
{
    [Header("Insert the DoorGO which to move")]
    [SerializeField]
    private GameObject door;

    //[SerializeField]
    private Vector3 moveDoorPosition;

    [Header("DOTWEEN Door's Animation Control")]
    [SerializeField]
    private int moveDoorOffset;
    [SerializeField]
    private float moveDoorDuration;
    [SerializeField]
    private bool moveDoorSnapping;

    [Header("DoorEvent ID")]
    [SerializeField]
    private int doorID;

    private void OnEnable()
    {
        //Fix the dumb bug where the door doesnt close properly
        //By locally save the init position
        moveDoorPosition = door.gameObject.transform.position;

        //We need to access the onDoorTriggerOpen event
        //We then subscribe our method to the event
        //So when Event trigger -> Method trigger
        DoorEventManager.onDoorTriggerClose += OnDoorwayClose;
        DoorEventManager.onDoorwayTriggerEnter += OnDoorwayOpen;
        
    }

    private void OnDisable()
    {
        //Unsub Events when stuff are deleted
        DoorEventManager.onDoorwayTriggerEnter -= OnDoorwayOpen;
        DoorEventManager.onDoorTriggerClose -= OnDoorwayClose;
    }

    //My method
    private void OnDoorwayOpen(int doorID)
    {
        //Setting up ID-checker
        if(doorID == this.doorID)
        {
            //Move door to the side -> Not realistic but it works ;_;
            door.transform.DOLocalMove(moveDoorPosition + door.transform.right * moveDoorOffset , moveDoorDuration , moveDoorSnapping);
        }
    }

    private void OnDoorwayClose(int doorID)
    {
        if(doorID == this.doorID)
        {
            //Close door by go back to OG position
            //Because DOMove when closing is bug tf out
            //Door doesnt close fully (note that in docu down)
            door.transform.DOMove(moveDoorPosition , moveDoorDuration , moveDoorSnapping);
        }
    }


}
