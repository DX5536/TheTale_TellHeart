using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileEventManager : MonoBehaviour
{
    //Remove TileAnimation Event
    public static event Action<int> onFloorTileRemove;
    public static void FloorTileRemove(int floorTileID)
    {
        if (onFloorTileRemove != null)
        {
            onFloorTileRemove(floorTileID);
        }
    }

    //Insert TileAnimation Event
    public static event Action<int> onFloorTileInsert;
    public static void FloorTileInsert(int floorTileID)
    {
        if (onFloorTileInsert != null)
        {
            onFloorTileInsert(floorTileID);
        }
    }
}
