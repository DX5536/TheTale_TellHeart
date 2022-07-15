using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Canvas_UI_Data", menuName = "StoryTelling/ScriptableObject/Canvas_UI_Data", order = 2)]
public class Canvas_UI_Data : ScriptableObject
{
    [SerializeField]
    private GameObject myStoryCanvas;

    //Set up properties
    public GameObject MyStoryCanvas
    {
        get { return myStoryCanvas; }
        set { myStoryCanvas = value; }
    }
    
}
