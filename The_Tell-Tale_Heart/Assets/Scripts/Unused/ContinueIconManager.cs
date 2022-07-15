using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueIconManager : MonoBehaviour
{
    [SerializeField]
    private GameObject continueIcon;

    [SerializeField]
    private string playContinueIcon_Float = "ContinueIcon_Float";

    [SerializeField]
    private Animator continueIcon_Animator;

    public Animator ContinueIcon_Animator
    {
        get { return continueIcon_Animator; }
        set { continueIcon_Animator = value; }
    }

    private void Start()
    {
        if (continueIcon.GetComponent<Animator>() == true)
        {
            continueIcon_Animator = continueIcon.gameObject.GetComponent<Animator>();
        }
    }
}
