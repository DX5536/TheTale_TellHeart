using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStoryColliderBehaviour : MonoBehaviour
{
    [Header ("Insert the GO Collider you want to turn of through event")]
    [SerializeField]
    private GameObject myStoryCollider;

    [SerializeField]
    private int storyID;

    private void OnEnable()
    {
        StoryEventManager.onPreMurderEvent += ActivateStoryCollider;
    }

    private void OnDisable()
    {
        StoryEventManager.onPreMurderEvent -= ActivateStoryCollider;
    }

    private void ActivateStoryCollider(int storyID)
    {
        if (storyID == this.storyID)
        {
            myStoryCollider.SetActive(true);
        }  
    }
}
