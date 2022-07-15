using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxCollider_Story : MonoBehaviour
{
    //Refer our S.O.
    [SerializeField]
    private DisplayText_Data myDisplayText_Data;

    //Refer our StoryCanvas' Tag
    [SerializeField]
    private string currentStoryCanvasTag;
    //Refer our Story Canvas
    private GameObject currentStoryCanvas;

    [SerializeField]
    private string player = "Player";

    [Header("Toggle TextPanel On when text playing & Off when not playing")]
    [SerializeField]
    private string textPanelAnimationManagerTag = "TextPanelAnimationManager";
    private GameObject textPanelAnimationManager;

    private TextPanelAnimationController textPanelAnimationController;
    private FloorHandler_InternalManager myInternalManager;

    [Header("Refer to values edited in Option")]
    [SerializeField]
    private string optionValueTag = "OptionValue";

    //OnEnable instead of Start because of other box colliders which will not be active during Start
    void OnEnable()
    {
        //Find our Story Canvas through Tag & Save it in local Var
        currentStoryCanvas = GameObject.FindGameObjectWithTag(currentStoryCanvasTag);

        //Find Animator
        textPanelAnimationManager = GameObject.FindGameObjectWithTag(textPanelAnimationManagerTag);
        myInternalManager = this.gameObject.GetComponentInParent<FloorHandler_InternalManager>();

        /*if (textPanelAnimationManager.GetComponent<TextPanelAnimationController>() != null)
        {
            textPanelAnimationController = textPanelAnimationManager.gameObject.GetComponent<TextPanelAnimationController>();
        }*/
    }
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            //Animator animator = textPanelAnimationController.TextPanelAnimator;
            //animator.Play("TurnOnTextPanel");

            //Now I want the S.O. in Story Canvas to be replace with THE S.O. in THIS GameObject
            currentStoryCanvas.GetComponent<Solo_DisplayText_Story>().CurrentDisplayText_Data = myDisplayText_Data;

            //Once it's assigned to the S.O. in Story Canvas -> Trigger the DisplayProtagonistStory()
            currentStoryCanvas.GetComponent<Solo_DisplayText_Story>().DisplayProtagonistStory();
            
            //Debug.Log("Player has entered me D;");
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            //Debug.Log("Player has exit " + gameObject.name);

            //Small Check is this is the special FloorHandler Colliders with StoryText
            if(myInternalManager != null)
            {
                GameObject zeroChildHandler = myInternalManager.MyChildrenHandlers[0];

                zeroChildHandler.SetActive(false);
                myInternalManager.Enable1stChildActivateTheRest();

                Debug.Log("This is a special BoxCollider_Story with FloorHandler");
            }

            //Turn Off the collider so it can't be activated again
            this.gameObject.SetActive(false);
        }
    }
}
