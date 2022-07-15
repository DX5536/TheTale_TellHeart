using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoryEventManager : MonoBehaviour
{
    //Turn on StoryCollider Event
    public static event Action<int> onStoryColliderActivate;
    public static void StoryColliderActivate(int storyColliderID)
    {
        if (onStoryColliderActivate != null)
        {
            onStoryColliderActivate(storyColliderID);
        }
    }

    //Turn off StoryCollider Event
    public static event Action<int> onStoryColliderDeactivate;
    public static void StoryColliderDeactivate(int storyColliderID)
    {
        if (onStoryColliderDeactivate != null)
        {
            onStoryColliderDeactivate(storyColliderID);
        }
    }

    //Pre-Murder Event
    public static event Action<int> onPreMurderEvent;
    public static void PreMurderEvent(int storyID)
    {
        if (onPreMurderEvent != null)
        {
            onPreMurderEvent(storyID);
        }
    }

    //Murder Event
    public static event Action<int> onMurderEvent;
    public static void MurderEvent(int storyID)
    {
        if (onMurderEvent != null)
        {
            //Debug.Log("Play MurderEvent");
            onMurderEvent(storyID);
        }
    }

    //Post-Murder Event
    public static event Action<int> onPostMurderEvent;
    public static void PostMurderEvent(int storyID)
    {
        if (onPostMurderEvent != null)
        {
            //Debug.Log("Play PostMurderEvent");
            onPostMurderEvent(storyID);
        }
    }

    public static event Action<int> onFrontDoorRing;
    public static void FrontDoorRing(int storyID)
    {
        if (onFrontDoorRing != null)
        {
            onFrontDoorRing(storyID);
        }
    }

}