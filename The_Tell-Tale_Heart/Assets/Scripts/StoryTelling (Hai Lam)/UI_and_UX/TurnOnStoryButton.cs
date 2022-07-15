using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnStoryButton : MonoBehaviour
{
    [SerializeField]
    private GameObject myButton;

    [SerializeField]
    private GameObject whichStoryCanvas;

    // Start is called before the first frame update
    void Start()
    {
        myButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the canvas is active or not ((Read only state first))
        //Once story is over, canvas will be deactivated
        if (whichStoryCanvas.activeSelf == false)
        {
            //If canvas is off -> Turn on GO Button
            myButton.SetActive(true);
        }
    }
}
