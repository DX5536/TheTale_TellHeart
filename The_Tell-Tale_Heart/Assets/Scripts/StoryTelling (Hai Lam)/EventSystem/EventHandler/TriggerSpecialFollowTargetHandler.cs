using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpecialFollowTargetHandler : MonoBehaviour
{
    [Header ("Have to compare the GO directly instead of Tag")]
    [Header("Way  more specific as both Police share same Tag")]
    [SerializeField]
    private GameObject myPolice;

    [SerializeField]
    private int policeHandlerID;

    [SerializeField]
    private bool isPoliceInLivingRoom;

    // Start is called before the first frame update
    void Start()
    {
        //Starts with police NOT in LivingRoom
        isPoliceInLivingRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangePolicemanEvents();
    }

    //The collider in living room will act as EventSwitcher
    //FollowPlayers > FollowToSpecificSpot
    private void OnTriggerExit(Collider other)
    {
        //If police enter living Room > calls another event
        if (other.gameObject == myPolice)
        {
           isPoliceInLivingRoom = true;
           PolicemanEventManager.PolicemanArrivesLivingRoom(policeHandlerID);

           this.gameObject.SetActive(false);
        }

        else
        {
            Debug.Log("Not MY police");
        }

    }

    private void ChangePolicemanEvents()
    {
        if(isPoliceInLivingRoom == false)
        {
            //Starts the scene with Police follows Player
            //Trigger/Call this FollowsPlayer Event at the start
            //And continue until Player enter Living Room
            PolicemanEventManager.PolicemanFollowsPlayer(policeHandlerID);
        }

        else
        {
            return;
        }
    }
}
