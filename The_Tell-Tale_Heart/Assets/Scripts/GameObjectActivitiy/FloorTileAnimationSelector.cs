using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTileAnimationSelector : MonoBehaviour
{
    [Header("Insert all the RemoveableTile with Animator")]
    [SerializeField]
    private GameObject[] removeableFloorTilesList;

    List<Animator> animatorList = new List<Animator>();

    [SerializeField]
    private string removeTileParameter;

    private void Start()
    {
        //Check if list is 0 or not
        if (removeableFloorTilesList.Length >= 1)
        {
            for (int i = 0; i < removeableFloorTilesList.Length; i++)
            {
                //Fill up my AnimatorList with Animator of FloorTile
                animatorList.Add(removeableFloorTilesList[i].GetComponent<Animator>());
                //Turn off ANimator at the start
                animatorList[i].enabled = false;
            }
        }

        else
        {
            return;
        }
    }

    public void FindFloorTile(string floorTileName)
    {
        if (removeableFloorTilesList.Length >= 1)
        {
            for (int i = 0; i < removeableFloorTilesList.Length ; i++)
            {
                if(removeableFloorTilesList[i].name == floorTileName)
                {
                    animatorList[i].enabled = true;
                    animatorList[i].SetTrigger(removeTileParameter);

                }
            }
        }

        else
        {
            return;
        }
    }
}
