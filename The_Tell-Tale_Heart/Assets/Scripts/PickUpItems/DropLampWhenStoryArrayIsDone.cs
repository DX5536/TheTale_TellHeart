using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLampWhenStoryArrayIsDone : MonoBehaviour
{
    [Header("Insert playerTag > Auto Find")]
    [SerializeField]
    private string playerTag = "Player";
    private GameObject player;

    [Header("If storyArray is finished -> DropItem()")]
    [SerializeField]
    private GameObject myStoryArray;

    private SimpleGrabSystem myGrabSystem;
    private PickableItem myPickedItem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        myGrabSystem = player.GetComponent<SimpleGrabSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        myPickedItem = myGrabSystem.PickedItem;   
    }

    public void DropLampWhenDone()
    {
        if (myStoryArray.activeSelf == false)
        {
            if(myPickedItem != null)
            {
                myGrabSystem.DropItem(myPickedItem);
            }

            else
            {
                return;
            }
        }

        else
        {
            return;
        }
    }
}
