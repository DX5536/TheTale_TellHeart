using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorEventManager : MonoBehaviour
{
    //Open door Event
    public static event Action<int> onDoorwayTriggerEnter;
    public static void DoorwayTriggerEnter(int doorID)
    {
        //Check if event can even be play
        if(onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter(doorID);
            //Debug.Log(onDoorwayTriggerEnter + " has been triggered");
        }
    }

    //Close door Event
    public static event Action<int> onDoorTriggerClose;
    public static void DoorTriggerClose(int doorID)
    {
        //Check if event can even be play
        if (onDoorTriggerClose != null)
        {
            onDoorTriggerClose(doorID);
        }
    }
}
