using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public void ExitFromGame()
    {
        Application.Quit();
        Debug.Log("Game quit!");
    }
}
