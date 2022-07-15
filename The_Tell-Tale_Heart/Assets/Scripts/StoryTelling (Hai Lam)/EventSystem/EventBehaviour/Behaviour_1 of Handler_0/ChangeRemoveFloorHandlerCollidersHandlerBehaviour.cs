using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRemoveFloorHandlerCollidersHandlerBehaviour : MonoBehaviour
{
    [Header("All FloorColliders activate but deactivate differently")]
    [SerializeField]
    private GameObject[] myHandler_0s;

    [SerializeField]
    private int storyID;

    void Start()
    {
        for (int i = 0 ; i < myHandler_0s.Length ; i++)
        {
            myHandler_0s[i].gameObject.SetActive(false);
            if (myHandler_0s[i].gameObject.activeSelf == false)
            {
                foreach (Transform myChildrenHandler_0s in myHandler_0s[i].transform)
                {
                    //Debug.Log("My "  + myChildrenHandler_0s.name + "should be deactive");
                    myChildrenHandler_0s.gameObject.SetActive(false);
                }
            }

            
        }
    }

    private void OnEnable()
    {
        StoryEventManager.onPostMurderEvent += AllFloorTilesHandlerActivate;
    }

    private void OnDisable()
    {
        StoryEventManager.onPostMurderEvent -= AllFloorTilesHandlerActivate;
    }

    private void AllFloorTilesHandlerActivate(int storyID)
    {
        if(storyID == this.storyID)
        {
            //if 1 of the children is active everyone is active
            for (int i = 0 ; i < myHandler_0s.Length ; i++)
            {
                myHandler_0s[i].gameObject.SetActive(true);

                if (myHandler_0s[i].gameObject.activeSelf == true)
                {
                    foreach (Transform myChildrenHandler_0s in myHandler_0s[i].transform)
                    {
                        //Debug.Log("My " + myChildrenHandler_0s.name + "should be active");
                        myChildrenHandler_0s.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
