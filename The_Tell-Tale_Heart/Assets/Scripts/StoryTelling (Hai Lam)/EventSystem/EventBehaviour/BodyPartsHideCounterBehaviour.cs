using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsHideCounterBehaviour : MonoBehaviour
{
    [Header("When bodyPartHideAmount = the holeAmount.Length > Police come")]
    [Header("This counter will go up by 1 each body part is in hole")]
    [SerializeField]
    private GameObject[] allHoles;
    [SerializeField]
    private string holeTag = "Hole";

    private int holeAmount;
    private int bodyPartHideAmount;

    [Header("When all body parts are hidden > Load NextScene by calling Handler")]
    [SerializeField]
    private TriggerSpecialNextSceneColliderHandler handlerNextScene;

    [Header("And update whatever Quest to FinalQuest")]
    [SerializeField]
    private TriggerSpecialUpdateFinalQuestHandler handlerUpdateFinalQuest;

    // Start is called before the first frame update
    void Start()
    {
        //Auto find > Me lazy
        allHoles = GameObject.FindGameObjectsWithTag(holeTag);

        //handlerNextScene = gameObject.GetComponent<TriggerSpecialNextSceneColliderHandler>();

        //Starts with 0
        bodyPartHideAmount = 0;

        //Save the amount of holes in Array (flexible)
        holeAmount = allHoles.Length;
    }

    private void OnEnable()
    {
        CounterEventManager.onBodyPartsHideCountUp += CountUp;
        CounterEventManager.onBodyPartsHideCountUp += AllBodyPartsAreHidden;

        CounterEventManager.onBodyPartsHideCountUp += CounterDebug;
    }

    private void OnDisable()
    {
        CounterEventManager.onBodyPartsHideCountUp -= CountUp;
        CounterEventManager.onBodyPartsHideCountUp -= AllBodyPartsAreHidden;

        CounterEventManager.onBodyPartsHideCountUp -= CounterDebug;
    }

    private void CountUp()
    {
        //Use < instead of != to avoid amount BIGGER
        if (bodyPartHideAmount < holeAmount)
        {
            bodyPartHideAmount++;

            //Debug.Log(bodyPartHideAmount + "x bodyparts have been hidden yet. Find more.");
        }
    }

    private void AllBodyPartsAreHidden()
    {
        if (bodyPartHideAmount == holeAmount)
        {
            //Trigger the Handler
            handlerNextScene.GetComponent<TriggerSpecialNextSceneColliderHandler>().TurnOnNextSceneCollider();
            //Update whatever Quest to the final Quest
            handlerUpdateFinalQuest.GetComponent<TriggerSpecialUpdateFinalQuestHandler>().FinalQuestToGoNextScene();

            //Debug.Log("All bodyparts have been hidden");
        }
    }

    //Debugging purpose ONLY
    private void CounterDebug()
    {
        if (bodyPartHideAmount == holeAmount)
        {
            //Debug.Log("All bodyparts have been hidden");
        }
        else
        {
            //Debug.Log(bodyPartHideAmount + "x bodyparts have been hidden yet. Find more.");
        }
    }
}
