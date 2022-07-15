using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField]
    GameEvent _gotLimb;

    [SerializeField]
    GameEvent _gotHeart;

    [SerializeField]
    GameEvent _gotLamp;

    [SerializeField]
    GameEvent _gotSaw;

    [SerializeField]
    GameEvent _pathBlockedMsg;

    [SerializeField]
    GameEvent _enterBedroom;

    [SerializeField]
    GameEvent _wrongTime;

    [SerializeField]
    GameEvent _wrongObject;

    [SerializeField]
    GameEvent _policeArrival;

    [SerializeField]
    private SimpleGrabSystem holdsItem;


    [SerializeField]
    private Camera characterCamera;

    private bool servantRoomOpen = false;

    public bool triggerEnding = false;

    public bool sawUsed = false;

    public bool limbUsed = false;

    public bool heartUsed = false;

    private void Update()
    {
        

        if (holdsItem.PickedItem == true)
        {
            Debug.Log("Yes it is picked up");

            if (holdsItem.PickedItem.tag == "Limbs")
            {
                Debug.Log("Picked up a limb");
                _gotLimb?.Invoke();
            }
            else if (holdsItem.PickedItem.tag == "Heart")
            {
                Debug.Log("Picked up a Heart");
                _gotHeart?.Invoke();
            }
            else if (holdsItem.PickedItem.tag == "Lamp")
            {
                Debug.Log("Picked up a Lamp");
                _gotLamp?.Invoke();
            }
            else if (holdsItem.PickedItem.tag == "Saw")
            {
                Debug.Log("Picked up a Saw");
                _gotSaw?.Invoke();
            }


            

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {


                if (holdsItem.PickedItem.tag == "Saw")
                {
                    sawUsed = true;
                }
                else if (holdsItem.PickedItem.tag == "Limbs")
                {
                    limbUsed = true;
                }
                else if (holdsItem.PickedItem.tag == "Heart")
                {
                    heartUsed = true;
                }
                else if(holdsItem.PickedItem.tag != "Heart" && holdsItem.PickedItem.tag != "Limbs" && holdsItem.PickedItem.tag != "Saw")
                {
                    
                }
            }
            
            
            

        

        }


    }

    void OnControllerColliderHit(ControllerColliderHit colliderHit)
    {
        if (colliderHit.gameObject.tag == "invWall")
        {
            Debug.Log("collieded with player");

         
                if (holdsItem.PickedItem == true)
                {
                    if (holdsItem.PickedItem.tag == "Lamp")
                    {
                        Debug.Log("can enter");
                        Destroy(colliderHit.gameObject);
                        Destroy(GameObject.FindWithTag("Lamp"));
                        _enterBedroom.Invoke();

                    }
                    else if (holdsItem.PickedItem.tag != "Lamp")
                    {
                        Debug.Log("can't enter");

                        servantRoomOpen = true;

                        _pathBlockedMsg.Invoke();
                    }
                }
                else if (holdsItem.PickedItem != true)
                {
                    _pathBlockedMsg.Invoke();

                    servantRoomOpen = true;
                }
           

           
           
        }
        else if (colliderHit.gameObject.tag == "invWall2")
        {

            Debug.Log("collieded with player");

            if (servantRoomOpen == true)
            {
                Destroy(colliderHit.gameObject);
            }
            else if(servantRoomOpen != true)
            {
                _wrongTime.Invoke();
            }
        }
        else if (colliderHit.gameObject.tag == "invWall3")
        {
            if(triggerEnding == true)
            {
                _policeArrival.Invoke();
            }
            else if(triggerEnding != true)
            {
                _wrongTime.Invoke();
            }
        }
    }

    


}
