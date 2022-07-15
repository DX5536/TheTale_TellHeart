using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Solo_DisplayText_Story : MonoBehaviour
{
    [Header("ScriptableObject of Story texts")]
    [SerializeField]
    private DisplayText_Data currentDisplayText_Data; //Ref the scriptable Object
    [SerializeField]
    private DisplayText_Data reset0DisplayText_Data;

    [Header("SoundFX")]
    [SerializeField]
    private AudioSource myTextSoundFX;

    //Set up a property for the displayText_Data -> So it can be switch later
    public DisplayText_Data CurrentDisplayText_Data
    {
        get { return currentDisplayText_Data; }
        set { currentDisplayText_Data = value; }
    }

    /*[Header("Toggle TextPanel On when text playing & Off when not playing")]
    [SerializeField]
    private GameObject textPanel;
    [SerializeField]
    private GameObject textPanelAnimationManager;

    private TextPanelAnimationController textPanelAnimationController;*/

    [Header("Refer to values edited in Option")]
    [SerializeField]
    private string optionValueTag = "OptionValue";

    private GameObject myOptionValueGO;
    private OptionValue optionValue;

    private void OnEnable()
    {
        //Reset whatever text inside to nothing
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }

    private void Start()
    {
        //When start make sure TextPanel is off
        /*textPanel.SetActive(false);
        textPanelAnimationController = textPanelAnimationManager.gameObject.GetComponent<TextPanelAnimationController>();*/

        myOptionValueGO = GameObject.FindGameObjectWithTag(optionValueTag);
        optionValue = myOptionValueGO.GetComponent<OptionValue>();

    }

    //A method that will display the text
    //Needs to be public to activate else where -> Through the Box/Object_Story scripts
    public void DisplayProtagonistStory()
    {
        //textPanel.SetActive(true);

        //With this the text being display is in the TMP Box
        currentDisplayText_Data.FullText = currentDisplayText_Data.WhichStoryTMP.GetComponent<TextMeshProUGUI>().text; 
        StartCoroutine(ShowText()); 
    }


    IEnumerator ShowText()
    {
        //For-Loop: Run as many times as fullText's character
        //+1 to avoid a character being eaten *nom nom*
        for (int i = 0; i < currentDisplayText_Data.FullText.Length + 1; i++)
        {
            currentDisplayText_Data.CurrentText = currentDisplayText_Data.FullText.Substring(0, i); //starts at 0 to i
            this.GetComponent<TextMeshProUGUI>().text = currentDisplayText_Data.CurrentText; //put currentDisplayText_Data.CurrentText in TMP's text box

            myTextSoundFX.Play();

            yield return new WaitForSeconds(optionValue.FlowTextDelay); //wait for delay-Amount of second
        }

        //Close text Box when For-Loop is finished
        yield return new WaitForSeconds(optionValue.CloseTextDelay);

        //textPanelAnimationController.TurnOffTextPanel();

        //Grab the TMP component in this GameObject
        //And replace it with the Reset0DisplayText_Data
        //Aka. Display no text
        this.gameObject.GetComponent<TextMeshProUGUI>().text = reset0DisplayText_Data.WhichStoryTMP.GetComponent<TextMeshProUGUI>().text;

        currentDisplayText_Data.HasTextBeenPlayed = true;
        //textPanel.gameObject.SetActive(false); //Turn off TextPanel
    }
}
