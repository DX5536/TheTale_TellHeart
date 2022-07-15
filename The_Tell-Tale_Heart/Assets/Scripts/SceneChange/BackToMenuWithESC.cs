using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuWithESC : MonoBehaviour
{
    //Reference the scriptable object
    [SerializeField]
    private MainMenuData mainMenuData;

    // Update is called once per frame
    void Update()
    {

        //Press ESC to go back to Menu
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }

    //Public cuz GoodEnding-Button use this method too
    public void LoadMainMenu()
    {
        //Load our MenuScene -> BuildIndex 0
        SceneManager.LoadScene(mainMenuData.WhichSceneIndexToLoad);
    }
}