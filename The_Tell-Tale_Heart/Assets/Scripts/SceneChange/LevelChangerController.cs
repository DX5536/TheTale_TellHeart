using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerController : MonoBehaviour
{
    [SerializeField]
    private MainMenuData loadNextScene;

    [SerializeField]
    private Animator sceneTransitAnimator;

    [SerializeField]
    private string fadeOutTrigger = "FadeOut";

    [SerializeField]
    private string resetNullTrigger = "ResetToNull";

    [SerializeField]
    private string fadeInTrigger = "FadeIn";
    private string fadeInAnimation = "FadeInAnimation";

    private void OnEnable()
    {
        sceneTransitAnimator.SetTrigger(fadeInTrigger);
    }

    //ContinueButton Trigger FadeOUt Animation
    public void FadeToLevel()
    {
        //Starts with fading
        sceneTransitAnimator.SetTrigger(fadeOutTrigger);
    }

    //Once FadeOut is finished -> trans scene
    public void FadeOnComplete()
    {
        //Load the scene
        SceneManager.LoadScene(loadNextScene.WhichSceneIndexToLoad);
    }

    public void ResetToNullState()
    {
        sceneTransitAnimator.SetTrigger(resetNullTrigger);
    }

}