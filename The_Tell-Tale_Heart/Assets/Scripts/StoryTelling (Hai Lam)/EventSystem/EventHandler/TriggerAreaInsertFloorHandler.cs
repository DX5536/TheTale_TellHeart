using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaInsertFloorHandler : MonoBehaviour
{
    [SerializeField]
    private string bodyPartTag;

    [SerializeField]
    private int holeColliderID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(bodyPartTag))
        {
            TileEventManager.FloorTileInsert(holeColliderID);
            //Debug.Log("A bodypart has entered HoleEvent");
        }
    }
}
