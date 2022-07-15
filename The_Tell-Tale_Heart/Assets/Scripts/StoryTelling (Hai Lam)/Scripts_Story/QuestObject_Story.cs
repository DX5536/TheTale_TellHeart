using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject_Story : MonoBehaviour
{
    //Refer our S.O.
    [SerializeField]
    private DisplayText_Data myDisplayText_Data;

    //Refer our Story Canvas
    //[SerializeField]
    private GameObject currentQuestCanvas;

    //Refer our StoryCanvas' Tag
    [SerializeField]
    private string currentQuestCanvasTag;

    // Start is called before the first frame update
    void Start()
    {
        //Find our Story Canvas through Tag & Save it in local Var
        currentQuestCanvas = GameObject.FindGameObjectWithTag(currentQuestCanvasTag);
    }

    //a public method that will be activated in SelectionManager.cs -> Only highlighted Object -> Through L.Mouse click
    public void UpdateObjectQuest()
    {
        //Now I want the S.O. in Story Canvas to be replace with THE S.O. in THIS GameObject
        currentQuestCanvas.GetComponent<Quest_DisplayText_Story>().CurrentDisplayText_Data = myDisplayText_Data;

        //Once it's assigned to the S.O. in Story Canvas -> Trigger DisplayQuest
        currentQuestCanvas.GetComponent<Quest_DisplayText_Story>().DisplayQuest();
    }
}
