using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPanelState : MonoBehaviour
{
    [SerializeField]
    private bool isTurnOnTextPanelFinished;

    public bool IsTurnOnTextPanelFinished
    {
        get { return isTurnOnTextPanelFinished;}
        set { isTurnOnTextPanelFinished = value;}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetIsTurnOnTextPanelFinished()
    {
        isTurnOnTextPanelFinished = true;
    }

    public void ResetIsTurnOnTextPanelFinished()
    {
        isTurnOnTextPanelFinished = false;
    }
}
