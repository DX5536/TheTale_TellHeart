using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHandler_InternalManager : MonoBehaviour
{
    [Header("If one GO is deactived -> everyone is deactivated (vice versa).")]
    [Header("Insert all the little Handlers inside.")]
    [SerializeField]
    private GameObject[] myChildrenHandlers;


    public GameObject[] MyChildrenHandlers
    {
        get { return myChildrenHandlers; }
        set { myChildrenHandlers = value; }
    }

    //Make sure all the chhildren start as inactive
    private void Start()
    { 
        for (int i = 0; i < myChildrenHandlers.Length; i++)
        {
            myChildrenHandlers[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        //DEBUG ONLY
        Enable1stChildActivateTheRest();
    }

    //Kinda kniffy if non-1st Child is deactivate > The rest doesnt follow
    //Workaround by looking at 1st Child only
    public void Enable1stChildActivateTheRest()
    {

        //if 1st of the children is active everyone is active
        for (int i = 0 ; i < myChildrenHandlers.Length ; i++)
        {
            if (myChildrenHandlers[i].gameObject.activeSelf == true)
            {
                foreach (GameObject myChildrenHandler in myChildrenHandlers)
                {
                    myChildrenHandler.SetActive(true);
                }
            }

            //If 1st child is off everyone is off
            else
            {
                foreach (GameObject myChildrenHandler in myChildrenHandlers)
                {
                    myChildrenHandler.SetActive(false);
                }
            }
        }
    }
}
