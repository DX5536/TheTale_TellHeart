using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChangeFollowTargetBehaviour : MonoBehaviour
{
    [Header("Our player >  Tag for laziness")]
    [SerializeField]
    private string playerTag = "Player";
    private GameObject playerGO;
    private Transform playerTarget;

    [Header("Our policeman with NavMeshAgent")]
    [SerializeField]
    private GameObject myPoliceGO;
    [SerializeField]
    private int myPoliceID;
    private NavMeshAgent navAgent;

    [Header("New spots' targets for Policemen when they enter living room")]
    [SerializeField]
    private GameObject livingRoomSpotGO;
    private Transform livingRoomSpotTarget;

    [Header("This collider will activate once Police in LivingR")]
    [SerializeField]
    private GameObject policeDialogCollider;

    private void OnEnable()
    {
        PolicemanEventManager.onPolicemanFollowsPlayer += DestinationPlayer;
        PolicemanEventManager.onPolicemanArrivesLivingRoom += DestinationLivingRoomSpot;
    }

    private void OnDisable()
    {
        PolicemanEventManager.onPolicemanFollowsPlayer -= DestinationPlayer;
        PolicemanEventManager.onPolicemanArrivesLivingRoom -= DestinationLivingRoomSpot;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag(playerTag);
        playerTarget = playerGO.transform;
        livingRoomSpotTarget = livingRoomSpotGO.transform;

        navAgent = myPoliceGO.GetComponent<NavMeshAgent>();

        policeDialogCollider.SetActive(false);
    }

    private void DestinationPlayer(int myPoliceID)
    {
        //Keep following Player
        if(myPoliceID == this.myPoliceID)
        {
            //Following player by having Player as destination
            navAgent.SetDestination(playerTarget.position);
        }
    }

    private void DestinationLivingRoomSpot(int myPoliceID)
    {
        //Once I enter the living room -> Police go to sofa and table
        //No more following player
        if (myPoliceID == this.myPoliceID)
        {
            //Move to specific spot in LivingR
            navAgent.SetDestination(livingRoomSpotTarget.position);

            //Set stopping distance to 0 so they are as close as target as possible
            //And doesnt float around
            navAgent.stoppingDistance = 0;

            //Turn on DialogCollider
            policeDialogCollider.SetActive(true);
        }
    }
}
