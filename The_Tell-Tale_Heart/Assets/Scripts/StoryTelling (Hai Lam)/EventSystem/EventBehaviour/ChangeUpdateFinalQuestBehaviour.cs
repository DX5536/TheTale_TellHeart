using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUpdateFinalQuestBehaviour : MonoBehaviour
{
    [Header("The Behaviour is the same as QuestCollider without BoxCollider")]
    [Header("Basically an invisible Quest/StoryObject_Story")]
    [SerializeField]
    private GameObject myFinalQuestStoryObject;

    [SerializeField]
    private int questID;

    private QuestObject_Story myFinalQuestStoryObject_Story;
    private SelectableObject_Story myFinalSelectableStoryObject_Story;
    

    // Start is called before the first frame update
    void Start()
    {
        myFinalQuestStoryObject_Story = myFinalQuestStoryObject.GetComponent<QuestObject_Story>();
        myFinalSelectableStoryObject_Story = myFinalQuestStoryObject.GetComponent<SelectableObject_Story>();
    }

    private void OnEnable()
    {
        StoryEventManager.onFrontDoorRing += UpdateFinalQuestObject;
        StoryEventManager.onFrontDoorRing += UpdateFinalStoryObject;
    }

    private void OnDisable()
    {
        StoryEventManager.onFrontDoorRing -= UpdateFinalQuestObject;
        StoryEventManager.onFrontDoorRing -= UpdateFinalStoryObject;
    }

    private void UpdateFinalQuestObject(int questID)
    {
        if (questID == this.questID)
        {
            myFinalQuestStoryObject_Story.UpdateObjectQuest();
            Debug.Log("Should update to final Quest");
        }
    }

    private void UpdateFinalStoryObject(int storyID)
    {
        if (storyID == this.questID)
        {
            myFinalSelectableStoryObject_Story.ShowObjectStory();
            Debug.Log("Should play final Monolog");
        }
    }
}
