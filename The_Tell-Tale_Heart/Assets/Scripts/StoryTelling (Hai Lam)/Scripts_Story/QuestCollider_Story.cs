using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestCollider_Story : MonoBehaviour
{
    [SerializeField]
    private string player = "Player";

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

    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            //Now I want the S.O. in Story Canvas to be replace with THE S.O. in THIS GameObject
            currentQuestCanvas.GetComponent<Quest_DisplayText_Story>().CurrentDisplayText_Data = myDisplayText_Data;

            //Once it's assigned to the S.O. in Story Canvas -> Trigger DisplayQuest
            currentQuestCanvas.GetComponent<Quest_DisplayText_Story>().DisplayQuest();

            //Debug.Log("Player has entered me D;");
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            //Debug.Log("Player has exit me :D");
            //Turn Off the collider so it can't be activated again
            this.gameObject.SetActive(false);
        }
    }
}
