using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    [Header("Make Player freeze when StoryArray is playing")]
    [SerializeField]
    private string playerTag = "Player";
    private GameObject player;

    private float localSpeed;
    private PlayerMovement myPlayerMovement;

    [Header("Insert the Story Array")]
    [SerializeField]
    private GameObject arrayStoryGO;

    [SerializeField]
    private float yAngleFromPeeking;

    private bool updateYAngle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        gameObject.SetActive(true);
        myPlayerMovement = player.GetComponent<PlayerMovement>();
        localSpeed = myPlayerMovement.Speed;
        updateYAngle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateYAngle)
        {
            yAngleFromPeeking = transform.rotation.eulerAngles.y;
        }

        if (arrayStoryGO.activeSelf == true)
        {
            updateYAngle = false;
            myPlayerMovement.Speed = 0;

            //Freeze rotation too
            transform.rotation = Quaternion.Euler(transform.eulerAngles.z , yAngleFromPeeking , transform.eulerAngles.z);
        }

        else
        {
            myPlayerMovement.Speed = localSpeed;
            updateYAngle = true;
        }
    }
}
