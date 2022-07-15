using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaRemoveFloorHandler : MonoBehaviour
{
    [SerializeField]
    private string player;

    [SerializeField]
    private int floorTileColliderID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            TileEventManager.FloorTileRemove(floorTileColliderID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.SetActive(false);
    }
}
