using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearWay : MonoBehaviour
{
    [SerializeField]
    GameEvent _pathBlockedMsg;

    [SerializeField]
    GameEvent _enterBedroom;

    [SerializeField]
    private SimpleGrabSystem itemCheck;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "MainCamera")
        {
            Debug.Log("collieded with player");

            if(itemCheck.PickedItem.tag == "Lamp")
            {
                Debug.Log("can enter");

                _enterBedroom.Invoke();
            }
            else if(itemCheck.PickedItem.tag != "Lamp")
            {
                Debug.Log("can't enter");

                _pathBlockedMsg.Invoke();
            }
        }
    }

    public void clearPath()
    {
        Destroy(this);
    }


}
