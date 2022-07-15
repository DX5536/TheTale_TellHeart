using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText_Story : MonoBehaviour
{
    [SerializeField]
    private DisplayText_Data currentDisplayText_Data; //Ref the scriptable Object

    //Set up a property for the displayText_Data -> So it can be switch later
    public DisplayText_Data CurrentDisplayText_Data
    {
        get { return currentDisplayText_Data; }
        set { currentDisplayText_Data = value; }
    }

    [Header("Refer to values edited in Option")]
    [SerializeField]
    private string optionValueTag = "OptionValue";

    private GameObject myOptionValueGO;
    private OptionValue optionValue;

    // Start is called before the first frame update
    void Start()
    {
        myOptionValueGO = GameObject.FindGameObjectWithTag(optionValueTag);
        optionValue = myOptionValueGO.GetComponent<OptionValue>();

        currentDisplayText_Data.FullText = currentDisplayText_Data.WhichStoryTMP.GetComponent<TextMeshProUGUI>().text; //With this the text being display is in the TMP Box
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

            yield return new WaitForSeconds(optionValue.FlowTextDelay); //wait for delay-Amount of second
        }

        //Close text Box when For-Loop is finished
        yield return new WaitForSeconds(optionValue.CloseTextDelay);
        currentDisplayText_Data.HasTextBeenPlayed = true;
        //this.gameObject.SetActive(false);
    }
}
