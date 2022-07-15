using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelChangerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject levelChanger;
    private Animator levelChangerAnimator;
    private LevelChangerController levelChangerController;

    [SerializeField]
    private string fadeOutState;


    private void OnEnable()
    {
        PolicemanEventManager.onFinishedDialogues += FadeOut;
    }

    private void OnDisable()
    {
        PolicemanEventManager.onFinishedDialogues -= FadeOut;
    }

    private void Start()
    {
        levelChangerAnimator = levelChanger.GetComponent<Animator>();
        levelChangerController = levelChanger.GetComponent<LevelChangerController>();
    }

    private void FadeOut()
    {
        levelChanger.SetActive(true);
        levelChangerAnimator.Play(fadeOutState);
        //levelChangerController.FadeToLevel();

        Debug.Log("Controller should be fadding");
    }
}
