using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSetting : MonoBehaviour
{
    [SerializeField]
    private string optionValueTag = "OptionValue";

    [Header("All the sliders in the option")]
    [SerializeField]
    private Slider flowTextDelaySlider;
    [SerializeField]
    private Slider closeTextDelaySlider;
    [SerializeField]
    private Toggle isQuestDisplayedToggle;

    private GameObject myOptionValueGO;
    private OptionValue optionValue;

    private void Start()
    {
        myOptionValueGO = GameObject.FindGameObjectWithTag(optionValueTag);
        optionValue = myOptionValueGO.GetComponent<OptionValue>();

        //Paste whatever value of OptionValue to Slider first
        flowTextDelaySlider.value = optionValue.FlowTextDelay;
        closeTextDelaySlider.value = optionValue.CloseTextDelay;
        isQuestDisplayedToggle.isOn = optionValue.IsQuestDisplayed;
    }

    public void SetFlowTextDelay ()
    {
        flowTextDelaySlider.value = Mathf.Round(flowTextDelaySlider.value * 100f) / 100;
        optionValue.FlowTextDelay = flowTextDelaySlider.value;

        PlayerPrefs.SetFloat("MyFlowTextDelay", optionValue.FlowTextDelay);
    }

    public void SetCloseTextDelay()
    {
        closeTextDelaySlider.value = Mathf.Round(closeTextDelaySlider.value * 100f) / 100;
        optionValue.CloseTextDelay = closeTextDelaySlider.value;

        PlayerPrefs.SetFloat("MyCloseTextDelay" , optionValue.CloseTextDelay);
    }

    public void SetIsQuestDisplayedValue()
    {
        if(isQuestDisplayedToggle.isOn == true)
        {
            optionValue.IsQuestDisplayed = true;
        }

        else
        {
            optionValue.IsQuestDisplayed = false;
        }

        PlayerPrefs.SetInt("MyIsQuestDisplayed" , (optionValue.IsQuestDisplayed ? 1 : 0));
    }
}
