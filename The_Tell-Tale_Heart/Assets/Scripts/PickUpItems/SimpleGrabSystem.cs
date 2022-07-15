using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrabSystem : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera; //Ref to character/Main camera

    [SerializeField]
    private Transform slot; //Ref to our grab slot

    [SerializeField]
    private PickableItem pickedItem; //Ref to our pickable Item

    public PickableItem PickedItem
    {
        get { return pickedItem; }
        set { pickedItem = value; }
    }

    private void Update()
    {

        //Execute only if player click l.mouse
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //check if player already has sth or not
            if (pickedItem == true)
            {
                //Yes, Drop that Item
                DropItem(pickedItem);
            }

            else
            {
                //Create a ray
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                //Shot a ray to find which object to pick, 2.5f is ray length
                if (Physics.Raycast(ray, out hit, 4f))
                {
                    //First check if object even pickable
                    //create a local var = temp save point
                    var pickable = hit.transform.GetComponent<PickableItem>();

                    //If return true
                    if (pickable == true)
                    {
                        PickUpItem(pickable);
                    }
                }
            }
        }
    }

    //Method for picking up item
    private void PickUpItem(PickableItem item)
    {
        pickedItem = item; //Add reference

        //Disable rigid body and set velocity
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        item.transform.SetParent(slot); //Add slot as parent

        //Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
    }

    //Method for dropping item
    public void DropItem(PickableItem item)
    {
        pickedItem = null; //Remove reference

        item.transform.SetParent(null); //Remove parent

        item.Rb.isKinematic = false; //Enable Rigid body to fall down

        //Make the player "throws" the object forward a bit
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
        //Make the player "throws" the object to the left a bit -> holded object a to the right
        item.Rb.AddForce(item.transform.right * - 1, ForceMode.VelocityChange);
    }
}
