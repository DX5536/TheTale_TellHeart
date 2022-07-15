using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorTileBehaviour : MonoBehaviour
{
    [Header("Insert a childHandler of the RemoveFloorHander")]
    //We will deactivate one when InsertingFloorTile is activates
    //So these colliders will never be activate again
    [SerializeField]
    private GameObject childRemoveFloorHandler;

    [Header("Insert (THIS) removeable FloorTile with Animator")]
    [SerializeField]
    private Animator mySelectedFloorTileAnimator;

    [Header("FloorTile ID")]
    [SerializeField]
    private int floorTileID;

    [Header("Play the Remove/Insert FloorTile Animation")]
    [SerializeField]
    private string removeFloorTileState;
    [SerializeField]
    private string insertFloorTileState;

    private void OnEnable()
    {
        TileEventManager.onFloorTileRemove += RemovingSelectedFloorTile;
        TileEventManager.onFloorTileInsert += InsertingSelectedFloorTile;
    }

    private void OnDisable()
    {
        TileEventManager.onFloorTileRemove -= RemovingSelectedFloorTile;
        TileEventManager.onFloorTileInsert -= InsertingSelectedFloorTile;
    }

    private void RemovingSelectedFloorTile(int floorTileID)
    {
        if (floorTileID == this.floorTileID)
        {
            mySelectedFloorTileAnimator.Play(removeFloorTileState);
            Debug.Log("I should remove floor");
        }
    }

    private void InsertingSelectedFloorTile(int floorTileID)
    {
        if (floorTileID == this.floorTileID)
        {
            mySelectedFloorTileAnimator.Play(insertFloorTileState);
            childRemoveFloorHandler.SetActive(false);
            //Debug.Log("FloorTile insert back");
        }
        
    }
}
