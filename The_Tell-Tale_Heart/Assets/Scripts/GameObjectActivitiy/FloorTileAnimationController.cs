using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTileAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator floorTileAnimator;

    [Header("Parameter (Trigger) names")]
    [SerializeField]
    private string insertTileParameter;
    [SerializeField]
    private string removeTileParameter;

    public Animator FloorTileAnimator
    {
        get { return floorTileAnimator; }
        set { floorTileAnimator = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        floorTileAnimator.keepAnimatorControllerStateOnDisable = false;
    }

    public void InsertingFloorTile(int floorTileID)
    {
        floorTileAnimator.SetTrigger(insertTileParameter);
    }

    public void RenovingFloorTile()
    {
        floorTileAnimator.SetTrigger(removeTileParameter);
    }
}
