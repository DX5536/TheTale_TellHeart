using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaRemoveFloorCollidersHandler : MonoBehaviour
{
    [Header("Player kills OldM > All possible Tile to be remove are activated")]
    [Header("Player have to search around the house")]
    [Header("All FloorCollider activate but deactivate differently")]
    [SerializeField]
    private string player = "Player";
    [SerializeField]
    private int floorTileID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            StoryEventManager.PostMurderEvent(floorTileID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            this.gameObject.SetActive(false);
        }
    }
}
