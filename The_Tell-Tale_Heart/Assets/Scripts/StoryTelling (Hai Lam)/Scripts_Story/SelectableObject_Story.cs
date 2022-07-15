using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject_Story : MonoBehaviour
{
    //Refer our S.O.
    [SerializeField]
    private DisplayText_Data myDisplayText_Data;

    //Refer our StoryCanvas' Tag
    [SerializeField]
    private string currentStoryCanvasTag;

    private GameObject currentStoryCanvas;

    /*[Header("Toggle TextPanel On when text playing & Off when not playing")]
    [SerializeField]
    private string textPanelAnimationManagerTag = "TextPanelAnimationManager";

    private GameObject textPanelAnimationManager;
    private TextPanelAnimationController textPanelAnimationController;*/

    // Start is called before the first frame update
    void Start()
    {
        //Find our Story Canvas through Tag & Save it in local Var
        currentStoryCanvas = GameObject.FindGameObjectWithTag(currentStoryCanvasTag);

        //Find Animator
        /*textPanelAnimationManager = GameObject.FindGameObjectWithTag(textPanelAnimationManagerTag);
        if (textPanelAnimationManager.GetComponent<TextPanelAnimationController>() != null)
        {
            textPanelAnimationController = textPanelAnimationManager.gameObject.GetComponent<TextPanelAnimationController>();
        }*/
    }
    public void ShowTextPanel()
    {
        //Animator animator = textPanelAnimationController.TextPanelAnimator;
        //animator.Play("TurnOnTextPanel");
    }

    //a public method that will be activated in SelectionManager.cs -> Only highlighted Object -> Through L.Mouse click
    public void ShowObjectStory()
    {
        //ShowTextPanel();

        //Now I want the S.O. in Story Canvas to be replace with THE S.O. in THIS GameObject
        currentStoryCanvas.GetComponent<Solo_DisplayText_Story>().CurrentDisplayText_Data = myDisplayText_Data;

        //Once it's assigned to the S.O. in Story Canvas -> Trigger the DisplayProtagonistStory()
        currentStoryCanvas.GetComponent<Solo_DisplayText_Story>().DisplayProtagonistStory();
    }
}
