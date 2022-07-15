using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTileAnimationTriggerCollider : MonoBehaviour
{
    [Header("insertFloorTile when BodyParts hit Collider")]
    [SerializeField]
    private GameObject floorTileAnimationManager;
    [SerializeField]
    private string insertFloorTileState;

    [SerializeField]
    private int thisFloorTileID;

    [SerializeField]
    private string bodyPartsTag;

    private Animator localAnimator;

    private FloorTileAnimationController floorTileAnimationController;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        floorTileAnimationController = floorTileAnimationManager.gameObject.GetComponent<FloorTileAnimationController>();
        localAnimator = floorTileAnimationController.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(bodyPartsTag))
        {
            //localAnimator.Play(insertFloorTileState);

            Debug.Log("A bodypart has entered");
            floorTileAnimationController.InsertingFloorTile(thisFloorTileID);
        }
    }
}
