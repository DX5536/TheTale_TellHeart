using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePauseGame : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBGPanel;

    [SerializeField]
    private GameObject dialogueBGPanelFreeCursor;
    private FreeMouseCursor freeCursorStatus;

    private void Start()
    {
        freeCursorStatus = dialogueBGPanelFreeCursor.GetComponent<FreeMouseCursor>();
    }

    private void Update()
    {
        //If this Panel is on = Freeze everything beside DialogueSystem
        //Panel is ON + Game is NOT paused
        if (dialogueBGPanel.activeSelf == true && !PauseMenu.GetInstance().IsPaused)
        {
            //Freeze
            Time.timeScale = 0f;
            //Unlock mouse cursor to select choices
            freeCursorStatus.UnlockCursor();
        }

        //Panel is off + Game is NOT paused
        else if (dialogueBGPanel.activeSelf == false && !PauseMenu.GetInstance().IsPaused)
        {
            //Play normal
            Time.timeScale = 1f;
            //Lock Cursor back to screen
            freeCursorStatus.LockCursorToMidScreen();
        }
    }
}
