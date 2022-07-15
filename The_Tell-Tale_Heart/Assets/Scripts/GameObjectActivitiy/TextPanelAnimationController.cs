using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextPanelAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator textPanelAnimator;

    [SerializeField]
    private TextPanelState state;

    [SerializeField]
    private string turnOffParameter;

    //private GameObject textPanel;

    public Animator TextPanelAnimator
    {
        get { return textPanelAnimator; }
        set { textPanelAnimator = value; }
    }

    private void Start()
    {
        textPanelAnimator.keepAnimatorControllerStateOnDisable = false;
    }

    public void TurnOffTextPanel()
    {
        if (state.IsTurnOnTextPanelFinished)
        {
            textPanelAnimator.SetTrigger(turnOffParameter);
        } 
    }

    


}
