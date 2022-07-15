using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "MainMenuData", menuName = "MainMenu/ScriptableObject/CreateMainMenuData", order = 1)]

public class MainMenuData : ScriptableObject
{
    [SerializeField]
    private string sceneName;

    //Reference which scene to load (its index)
    [SerializeField]
    private int whichSceneIndexToLoad;

    //Property
    public int WhichSceneIndexToLoad
    {
        get { return whichSceneIndexToLoad; }
        set { whichSceneIndexToLoad = value; }
    }
}