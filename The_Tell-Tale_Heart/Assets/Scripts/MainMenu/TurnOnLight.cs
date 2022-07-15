using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLight : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";

    [SerializeField]
    private GameObject myLamp;

    private PickableItem myPickableLamp;

    [SerializeField]
    private GameObject myLightSource;

    private Light myFlashLight;

    [SerializeField]
    private SimpleGrabSystem currentPickedUpItem;

    private bool isLightOn;

    //Read-Only Pro
    public bool IsLightOn
    {
        get { return isLightOn; }
        set { isLightOn = value; }
    }

    private void Start()
    {
        //Auto Find to avoid Error
        currentPickedUpItem = GameObject.FindGameObjectWithTag(playerTag).GetComponent<SimpleGrabSystem>();

        //Get and save the components in the vars
        myPickableLamp = myLamp.GetComponent<PickableItem>();
        myFlashLight = myLightSource.GetComponent<Light>();

        isLightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPickedUpItem.PickedItem == myPickableLamp)
        {
            TurnLightOnOff();
            //Debug.Log(currentPickedUpItem.PickedItem + " And " + myPickableLamp);
        }

        else
        {
            //Turn off Light if it's remove from Player Hand -> Avoid later conflicts with oldman Eye
            myFlashLight.enabled = false;
        }
    }

    void TurnLightOnOff()
    {
        //If it'S off -> Press F to turn ON
        if (myFlashLight.enabled == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                myFlashLight.enabled = true;
                isLightOn = true;
            }
        }

        else if (myFlashLight.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                myFlashLight.enabled = false;
                isLightOn = false;
            }
        }
    }
}
