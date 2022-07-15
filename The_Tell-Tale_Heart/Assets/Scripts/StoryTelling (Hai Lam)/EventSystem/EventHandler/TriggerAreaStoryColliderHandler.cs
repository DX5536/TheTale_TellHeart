using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaStoryColliderHandler : MonoBehaviour
{
    [SerializeField]
    private string player;

    [Header ("Insert the ID of the Story_Collider_Main_ID")]
    [SerializeField]
    private int storyColliderID;

    private void OnTriggerEnter(Collider other)
    {
        //Player front OldM door -> Go back to living room
        if (other.gameObject.CompareTag(player))
        {
            StoryEventManager.PreMurderEvent(storyColliderID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
