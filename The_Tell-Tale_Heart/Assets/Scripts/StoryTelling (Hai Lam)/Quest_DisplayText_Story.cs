using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest_DisplayText_Story : MonoBehaviour
{
    [SerializeField]
    private DisplayText_Data currentDisplayText_Data; //Ref the scriptable Object

    [Header("Refer to values edited in Option")]
    [SerializeField]
    private string optionValueTag = "OptionValue";

    [Header("SoundFX")]
    [SerializeField]
    private AudioSource myTextSoundFX;

    private GameObject myOptionValueGO;
    private OptionValue optionValue;

    private void Start()
    {
        myOptionValueGO = GameObject.FindGameObjectWithTag(optionValueTag);
        optionValue = myOptionValueGO.GetComponent<OptionValue>();

        //First Check (Has the ShowText Couroutine) -> Start the init quest
        currentDisplayText_Data.FullText = currentDisplayText_Data.WhichStoryTMP.GetComponent<TextMeshProUGUI>().text;
        CheckIsQuestDisplayedValue();
    }

    //Set up a property for the displayText_Data -> So it can be switch later
    public DisplayText_Data CurrentDisplayText_Data
    {
        get { return currentDisplayText_Data; }
        set { currentDisplayText_Data = value; }
    }

    //A method that will display the text
    //Needs to be public to activate else where -> Through the Box/Object_Story scripts
    public void DisplayQuest()
    {
        currentDisplayText_Data.FullText = currentDisplayText_Data.WhichStoryTMP.GetComponent<TextMeshProUGUI>().text; //With this the text being display is in the TMP Box
        CheckIsQuestDisplayedValue();
    }

    //This method is basically ShowText but with a check before: True? Play ShowText
    private void CheckIsQuestDisplayedValue()
    {
        //Check if IsQuestDisplay false > disable TMPRO component
        if (optionValue.IsQuestDisplayed == false)
        {
            //gameObject.SetActive(false);
            //this.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;

            //Instead of disable TMP -> Make TMP display nothing
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }

        else
        {
            //gameObject.SetActive(true);
            this.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            StartCoroutine(ShowText());
        }
    }

    IEnumerator ShowText()
    {
        //For-Loop: Run as many times as fullText's character
        //+1 to avoid a character being eaten *nom nom*
        for (int i = 0 ; i < currentDisplayText_Data.FullText.Length + 1 ; i++)
        {
            currentDisplayText_Data.CurrentText = currentDisplayText_Data.FullText.Substring(0 , i); //starts at 0 to i
            this.GetComponent<TextMeshProUGUI>().text = currentDisplayText_Data.CurrentText; //put currentDisplayText_Data.CurrentText in TMP's text box

            myTextSoundFX.Play();

            yield return new WaitForSeconds(optionValue.FlowTextDelay); //wait for delay-Amount of second
        }

        //Close text Box when For-Loop is finished
        yield return new WaitForSeconds(optionValue.CloseTextDelay);

        //Grab the TMP component in this GameObject
        //And replace it with the Reset0DisplayText_Data
        //Aka. Display no text
        //this.gameObject.GetComponent<TextMeshProUGUI>().text = reset0DisplayText_Data.WhichStoryTMP.GetComponent<TextMeshProUGUI>().text;

        currentDisplayText_Data.HasTextBeenPlayed = true;
    }
}
