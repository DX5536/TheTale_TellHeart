using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static PauseMenu instance;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject levelChanger;

    [SerializeField]
    private bool isPaused;

    [SerializeField]
    private FreeMouseCursor freeMouseCursor;

    public bool IsPaused
    {
        get { return isPaused; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != null)
        {
            Destroy(this);
        }
    }

    public static PauseMenu GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Making sure level changer is always ob at the start for Fade In aniamtion
        levelChanger.SetActive(true);

        //Making sure pausedMenu is deactivated when start scene
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //keep checking when player asked for a paused
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if game is already paused -> return game
            if(isPaused == true)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
    }


    public void PauseGame()
    {
        freeMouseCursor.UnlockCursor();

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        freeMouseCursor.LockCursorToMidScreen();

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
