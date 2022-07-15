using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] gamesounds;

   [SerializeField]
    private AudioSource walk;

   [SerializeField]
    private AudioSource landing;

    private AudioSource pickup;
    private AudioSource dooropen;
    private AudioSource doorclose;

    [SerializeField]
    private MovementCheck mc;
    void Start()
    {
        mc.GetComponent<MovementCheck>();

        /*
        gamesounds = GetComponents<AudioSource>();

        walk = gamesounds[0];
        pickup = gamesounds[1];
        dooropen = gamesounds[2];
        doorclose = gamesounds[3];
        */
    }

    private void Update()
    {
        if(mc.isMoving == true)
        {
            Debug.Log("Movement Detected");

            mc.isMoving = false;
            if(walk.isPlaying == false)
            {
                PlayWalk();
            }
            
        }
        else if(mc.isMoving != true)
        {
            walk.Stop();
        }

        if(mc.isLanding == true)
        {

            Debug.Log("Landing detected");

            
            if(landing.isPlaying == false)
            {

                PlayLanding();
            }
            mc.isLanding = false;
        }
        else if( mc.isLanding != true)
        {
            //landing.Stop();
        }
    }

    public void PlayWalk()
    {
        walk.PlayOneShot(walk.clip);
    }

    public void PlayLanding()
    {
        landing.PlayOneShot(landing.clip);
    }

    public void PlayPickUp()
    {
        pickup.Play();
    }

    public void PlayDoorOpen()
    {
        dooropen.Play();
    }

    public void PlayDoorClose()
    {
        doorclose.Play();
    }


    
}
