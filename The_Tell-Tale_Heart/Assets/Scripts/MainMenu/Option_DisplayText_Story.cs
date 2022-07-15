using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Option_DisplayText_Story : MonoBehaviour
{
    [SerializeField]
    private string optionValueTag = "OptionValue";

    [SerializeField]
    private bool isPreviewLoop = true;

    private GameObject myOptionValueGO;
    private OptionValue optionValue;

    private TextMeshProUGUI myPreviewText;

    // Start is called before the first frame update
    void Start()
    {
        myOptionValueGO = GameObject.FindGameObjectWithTag(optionValueTag);
        optionValue = myOptionValueGO.GetComponent<OptionValue>();

        myPreviewText = this.GetComponent<TextMeshProUGUI>();

        optionValue.FullText = myPreviewText.text;

        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        while (isPreviewLoop == true)
        {
            for (int i = 0 ; i < optionValue.FullText.Length + 1 ; i++)
            {
                optionValue.CurrentText = optionValue.FullText.Substring(0 , i); //starts at 0 to i
                this.GetComponent<TextMeshProUGUI>().text = optionValue.CurrentText; //put optionValue.CurrentText in TMP's text box

                yield return new WaitForSeconds(optionValue.FlowTextDelay); //wait for delay-Amount of second
            }

            //Close text Box when For-Loop is finished
            yield return new WaitForSeconds(optionValue.CloseTextDelay);
        }

    }
}
