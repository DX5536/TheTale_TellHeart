using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnStoryCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject myStoryCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //Check if the canvas is active or not ((Read only state first))
        if (myStoryCanvas.activeSelf != true)
        {
            //If GO is not active -> Turn on
            myStoryCanvas.SetActive(true);
        }
    }

    private void Update()
    {

    }

}
