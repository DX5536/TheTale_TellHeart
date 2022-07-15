using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeDisplayText_StoryWithRayBehaviour : MonoBehaviour
{
    [Header("Insert the GO with StoryArray")]
    [SerializeField]
    private GameObject myStoryArray;

    [SerializeField]
    private int storyID;

    private void OnEnable()
    {
        StoryEventManager.onMurderEvent += ActivateStoryArray;
    }
    private void OnDisable()
    {
        StoryEventManager.onMurderEvent -= ActivateStoryArray;
    }

    private void ActivateStoryArray(int storyID)
    {
        if (storyID == this.storyID)
        {
           myStoryArray.SetActive(true);
        } 
    }
}
