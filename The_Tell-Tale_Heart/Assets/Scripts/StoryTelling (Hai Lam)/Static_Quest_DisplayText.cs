using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Static_Quest_DisplayText : MonoBehaviour
{
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

        CheckIsQuestDisplayedValue();
    }

    // Update is called once per frame
    void Update()
    {
        //This is for Debug Purpose only
        //CheckIsQuestDisplayedValue();
    }

    private void CheckIsQuestDisplayedValue()
    {
        //Check if IsQuestDisplay false > disable TMPRO component
        if (optionValue.IsQuestDisplayed == false)
        {
            //gameObject.SetActive(false);
            this.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }

        else
        {
            //gameObject.SetActive(true);
            this.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}
