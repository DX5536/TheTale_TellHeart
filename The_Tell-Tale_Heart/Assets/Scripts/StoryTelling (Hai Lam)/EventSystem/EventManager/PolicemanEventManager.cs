using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PolicemanEventManager : MonoBehaviour
{
    public static event Action<int> onPolicemanFollowsPlayer;
    public static void PolicemanFollowsPlayer(int policemanID)
    {
        if (onPolicemanFollowsPlayer != null)
        {
            onPolicemanFollowsPlayer(policemanID);
            //Debug.Log("Police follows Player Event");
        }
    }

    public static event Action<int> onPolicemanArrivesLivingRoom;
    public static void PolicemanArrivesLivingRoom(int policemanID)
    {
        if(onPolicemanArrivesLivingRoom != null)
        {
            onPolicemanArrivesLivingRoom(policemanID);
            Debug.Log("Police arrive Living Room & move to Sofa");
        }
    }

    public static event Action onFinishedDialogues;
    public static void FinishedDialogues()
    {
        if (onFinishedDialogues != null)
        {
            onFinishedDialogues();
        }
    }
}
