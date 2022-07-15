using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCheck : MonoBehaviour
{
    private Vector3 lastPosition;
    private Transform myTransform;
    public bool isMoving;
    private bool inAir;
    public bool isLanding;

    [SerializeField]
    private PlayerMovement pm;

    //This script checks whether or not the object (in this case the player) is currently moving 

    void Start()
    {
        myTransform = transform;
        lastPosition = myTransform.position;
        isMoving = false;
        isLanding = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(pm.isGrounded == true)
        {
            if (myTransform.position != lastPosition)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            if(inAir == true)
            {
                isLanding = true;

                inAir = false;
            }
            else
            {
                isLanding = false;
            }

            lastPosition = myTransform.position;
        } 
       else if (pm.isGrounded != true)
        {
            inAir = true;
        }
        
    }

    //This iformation is passed to the SoundManager to play the walking sfx when moving
}
