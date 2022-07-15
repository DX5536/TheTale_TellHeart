using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string whichSceneIsThis_READ_ONLY;

    //Reference the scriptable object
    [SerializeField]
    private MainMenuData mainMenuData;

    [SerializeField]
    private string loadingScreenTag = "LoadingScreen";
    private GameObject loadingScreen;
    private Slider loadingBar;

    private void OnEnable()
    {
        //Find LoadingScreen
        loadingScreen = GameObject.FindGameObjectWithTag(loadingScreenTag);
        //If there is one > Get LoadingBar
        if (loadingScreen != null)
        {
            loadingBar = loadingScreen.GetComponentInChildren<Slider>();
        }
        //If no > return
        else
        {
            return;
        }
    }

    private void Start()
    {
        if(loadingScreen == null)
        {
            Debug.Log("There is no LoadingScreen");
            return;
        }

        else
        {
            loadingScreen.SetActive(false);  
        }
        
    }

    public void LoadSceneButton()
    {
        //Load the scene
        //Take the int number of the Scriptable Object and paste it here
        //SceneManager.LoadScene(mainMenuData.WhichSceneIndexToLoad); 

        if (loadingScreen == null)
        {
            SceneManager.LoadScene(mainMenuData.WhichSceneIndexToLoad);

            if(Time.timeScale == 0)
            {
                //Make sure Time.timeScale is back to 1f
                Time.timeScale = 1f;
            }
            
            Debug.Log("There is no LoadingScreen through Button");
        }

        else
        {
            StartCoroutine(LoadSceneAsynchronously());
        }
    }

    IEnumerator LoadSceneAsynchronously()
    {
        //Load Scene with Bar
        AsyncOperation myOperation = SceneManager.LoadSceneAsync(mainMenuData.WhichSceneIndexToLoad);
        loadingScreen.SetActive(true);

        //A while loop that keeps running is isDone is false
        while (!myOperation.isDone)
        {
            //Unity operation only goes from 0 to 0.9
            //With maff we can make it from 0 to 1 = 100% bar
            float progress = Mathf.Clamp01(myOperation.progress / 0.9f);
            loadingBar.value = progress;

            yield return null;
        }
    }
}