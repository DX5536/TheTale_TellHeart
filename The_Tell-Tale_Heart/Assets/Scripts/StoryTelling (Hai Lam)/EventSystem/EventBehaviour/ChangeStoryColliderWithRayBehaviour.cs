using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStoryColliderWithRayBehaviour : MonoBehaviour
{
    [Header("Insert the GO Collider you want to turn of through event")]
    [SerializeField]
    private GameObject myStoryCollider;

    [SerializeField]
    private int storyID;

    private void OnEnable()
    {
        StoryEventManager.onMurderEvent += ActivateStoryColliderWithRay;
    }

    private void OnDisable()
    {
        StoryEventManager.onMurderEvent -= ActivateStoryColliderWithRay;
    }

    private void ActivateStoryColliderWithRay(int storyID)
    {
        if (storyID == this.storyID)
        {
            myStoryCollider.SetActive(true);
            Debug.Log("Kill old man");
        }
    }
}
