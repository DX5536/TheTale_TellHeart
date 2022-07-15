using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionValue : MonoBehaviour
{
    //Make this a singleton
    private static OptionValue instance;

    [SerializeField]
    private float flowTextDelay; //Display Speed

    [SerializeField]
    private float closeTextDelay; //Waiting time to close text

    //[SerializeField]
    private float volume;

    [SerializeField]
    private bool isQuestDisplayed;

    private string fullText; //Show when all text is complete
    private string currentText = ""; //Starts with empty

    public float FlowTextDelay
    {
        get { return flowTextDelay; }
        set { flowTextDelay = value; }
    }

    public float CloseTextDelay
    {
        get { return closeTextDelay; }
        set { closeTextDelay = value; }
    }

    public float Volume
    {
        get { return volume; }
        set { volume = value; }
    }

    public bool IsQuestDisplayed
    {
        get { return isQuestDisplayed; }
        set { isQuestDisplayed = value; }
    }

    public string FullText
    {
        get { return fullText; }
        set { fullText = value; }
    }

    public string CurrentText
    {
        get { return currentText; }
        set { currentText = value; }
    }

    private void Awake()
    {
        //Create an instance
        if (instance != null)
        {
            Debug.Log("There are more than 1 OptionValue ");
            Destroy(this);
        }

        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void OnEnable()
    {
        //Check if there is any saved value: If yes > Load
        if (PlayerPrefs.HasKey("MyFlowTextDelay"))
        {
            flowTextDelay = PlayerPrefs.GetFloat("MyFlowTextDelay");
        }

        else
        {
            Debug.Log("There is no saved value");
        }

        if (PlayerPrefs.HasKey("MyCloseTextDelay"))
        {
            closeTextDelay = PlayerPrefs.GetFloat("MyCloseTextDelay");
        }

        if (PlayerPrefs.HasKey("MyIsQuestDisplayed"))
        {
            isQuestDisplayed = PlayerPrefs.GetInt("MyIsQuestDisplayed") != 0;
        }
    }

    //Full/Idiot Proof in case someone destroy in Editor
    private void OnDestroy()
    {
        if (instance = this)
        {
            instance = null;
        }
    }
}
