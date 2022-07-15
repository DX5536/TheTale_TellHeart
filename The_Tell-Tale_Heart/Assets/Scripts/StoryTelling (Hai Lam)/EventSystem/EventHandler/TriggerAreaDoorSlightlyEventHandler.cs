using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TriggerAreaDoorSlightlyEventHandler : MonoBehaviour
{
    [SerializeField]
    private string player;

    [SerializeField]
    private int doorSlightlyID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
{
            StoryEventManager.PreMurderEvent(doorSlightlyID);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.SetActive(false);
    }
}
