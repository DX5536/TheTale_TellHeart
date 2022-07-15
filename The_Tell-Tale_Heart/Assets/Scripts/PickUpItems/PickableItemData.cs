using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickableItemData", menuName = "PickableItems/ScriptableObject/CreatePickableItemData", order = 1)]

public class PickableItemData : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera; //Ref to character/Main camera

    [SerializeField]
    private Transform slot; //Ref to our grab slot

    [SerializeField]
    private PickableItem pickedItem; //Ref to our pickable Item

    //Properties for the variables
    public Camera CharacterCamera
    {
        get { return characterCamera; }
        set { characterCamera = value; }
    }

    public Transform Slot
    {
        get { return slot; }
        set { slot = value; }
    }

    public PickableItem PickedItem
    {
        get { return pickedItem; }
        set { pickedItem = value; }
    }
}
