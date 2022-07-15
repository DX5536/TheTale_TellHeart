using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpecialUpdateFinalQuestHandler : MonoBehaviour
{
    [Header("This is to update the Quest without Collider or SelectableObject")]
    [SerializeField]
    private int questStoryID;

    public void FinalQuestToGoNextScene()
    {
        StoryEventManager.FrontDoorRing(questStoryID);
        Debug.Log("Updating final quest for MainP");
    }
}
