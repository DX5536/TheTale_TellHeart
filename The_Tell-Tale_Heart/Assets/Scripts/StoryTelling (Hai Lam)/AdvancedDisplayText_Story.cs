using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdvancedDisplayText_Story : MonoBehaviour
{
    [SerializeField]
    private DisplayText_Data[] displayText_Datas; //Ref the Array contains all the Scriptable Object

    [Header("Refer to values edited in Option")]
    [SerializeField]
    private string optionValueTag = "OptionValue";

    private GameObject myOptionValueGO;
    private OptionValue optionValue;

    [Header("SoundFX")]
    [SerializeField]
    private AudioSource myTextSoundFX;

    // Start is called before the first frame update
    void Start()
    {
        myOptionValueGO = GameObject.FindGameObjectWithTag(optionValueTag);
        optionValue = myOptionValueGO.GetComponent<OptionValue>();

        GoThroughArrayContainsStory();

        //Starts the typewritter Effect :3c
        StartCoroutine(ShowText());
    }

    private void GoThroughArrayContainsStory()
    {
        //For-Loop: Run through all the displayText_Data's array containts Scriptable Objects

        //h = array.length for Scriptable Object
            //Technically [i] works too as it's a different loop but let's be consistent in this script :D
        for (int h = 0; h < displayText_Datas.Length; h++)
        {
            //Go through the list of S.O. in the array
            //Save the TMP.text value in FullText for ShowText() and with this the text being display is in the TMP Box
            displayText_Datas[h].FullText = displayText_Datas[h].WhichStoryTMP.GetComponent<TextMeshProUGUI>().text;

        }
    }

    IEnumerator ShowText()
    {
        //For-Loop: Run as many times as fullText's character
        //+1 to avoid a character being eaten *nom nom*
        
        //h = array.length for Scriptable Object
        //This first loop goes through the array contains Scripable Object
        for (int h = 0 ; h < displayText_Datas.Length; h++)
        {
            //i = characters in the text
            //this second loop goes through the array contain text's amount of characters
            for (int i = 0 ; i < displayText_Datas[h].FullText.Length+1 ; i++)
            {
                displayText_Datas[h].CurrentText = displayText_Datas[h].FullText.Substring(0 , i); //starts at 0 to i-amount of characters
                this.GetComponent<TextMeshProUGUI>().text = displayText_Datas[h].CurrentText; //put displayText_Data.CurrentText in TMP's text box

                myTextSoundFX.Play();
                //this.GetComponent<TextMeshProUGUI>().text = displayText_Datas[i].WhichStoryTMP.GetComponent<TextMeshProUGUI>().text; //2nd try and over-complicated

                yield return new WaitForSeconds(optionValue.FlowTextDelay); //wait for delay-Amount of second
            }

            //If not final Story.Text: Wait for CloseTextDelay's second
            yield return new WaitForSeconds(optionValue.CloseTextDelay);
            displayText_Datas[h].HasTextBeenPlayed = true;
        }

        //h = array.length for Scriptable Object
            //Technically [i] works too as it's a different loop but let's be consistent in this script :D
        for (int h = 0 ; h < optionValue.FlowTextDelay; h++)
        {
            //For final Story.Text: Close text Box when For-Loop (^) is finished
            yield return new WaitForSeconds(optionValue.CloseTextDelay);

            displayText_Datas[h].HasTextBeenPlayed = true;
            this.gameObject.SetActive(false);
        }
        
    }
}
