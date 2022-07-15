using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTilesActiveAtStart : MonoBehaviour
{
    [Header("This is to make sure FloorTile is active at start")]
    [Header("In case it was disable for testing purposes")]

    [SerializeField]
    private GameObject floorTile_RemovePart;

    // Start is called before the first frame update
    void Start()
    {
        //If it'S not active at Start > Set active
        if (!floorTile_RemovePart.activeSelf)
        {
            floorTile_RemovePart.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
