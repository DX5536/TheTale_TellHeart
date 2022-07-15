using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpecialNextSceneColliderHandler : MonoBehaviour
{
    [Header("Behaviour is the same just different Handler as box collider")]
    [SerializeField]
    private int handlerColliderID;

    public void TurnOnNextSceneCollider()
    {
        //If this method is called > Turn on my NextSceneHandler
        //Just a different Handler than a box collider
        //But the Behaviour is the same
        EventsEventManager.ColliderEventTriggerActivate(handlerColliderID);
        Debug.Log("I should be TurnOn my NextSceneCollider");
    }
}