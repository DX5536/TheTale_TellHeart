using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChangeDoorSlightlyBehaviour : MonoBehaviour
{
    [Header("Insert the DoorGO which to move")]
    [SerializeField]
    private GameObject door;

    //[SerializeField]
    private Vector3 moveDoorPosition;

    [Header("DOTWEEN Door's -SLIGHTLY- Animation Control")]
    [SerializeField]
    private int moveDoorSlightyOffset;
    [SerializeField]
    private float moveDoorSlightyDuration;
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
        StoryEventManager.onPreMurderEvent += OnDoorwayOpenSlightly;

    }

    private void OnDisable()
    {
        //Unsub Events when stuff are deleted
        StoryEventManager.onPreMurderEvent -= OnDoorwayOpenSlightly;
    }

    //My method
    private void OnDoorwayOpenSlightly(int doorID)
    {
        //Setting up ID-checker
        if (doorID == this.doorID)
        {
            //Move door to the side -> Not realistic but it works ;_;
            door.transform.DOLocalMove(moveDoorPosition + door.transform.right * moveDoorSlightyOffset , moveDoorSlightyDuration , moveDoorSnapping);
        }


    }

    private void OnDoorwayCloseSlighly(int doorID)
    {
        if (doorID == this.doorID)
        {
            //Close door by go back to OG position
            //Because DOMove when closing is bug tf out
            //Door doesnt close fully (note that in docu down)
            door.transform.DOMove(moveDoorPosition , moveDoorSlightyDuration , moveDoorSnapping);
        }

    }
}
