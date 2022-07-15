using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
    [Header("Panel_UI")]
    [SerializeField]
    private GameObject dialogBGPanel;
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private GameObject centerDot;

    [SerializeField]
    private Animator speakerPanelAnimator;

    [Header("TextMeshPro_UI")]
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    [SerializeField]
    private TextMeshProUGUI displayNameText;

    [Header("Choices UI")]
    [SerializeField]
    private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    [Header("Boolean values_READ ONLY")]
    [SerializeField]
    private bool isDialoguePlaying;
    [SerializeField]
    private bool canPlayerPressE;
    [SerializeField]
    private bool canStoryContinue;

    [Header("Non-Dialog TextPanel")]
    [SerializeField]
    private GameObject textPanel;

    [Header("Handler for LevelChanger > FadeOut")]
    [SerializeField]
    private TriggerSpecialLevelChangerHandler specialLevelChangerHandler;

    //This manager will be a singleton
    private static DialogueManager instance;

    [Header("Refer to values edited in Option")]
    [SerializeField]
    private string optionValueTag = "OptionValue";

    private GameObject myOptionValueGO; 
    private OptionValue optionValue;

    [Header("My ContinueIcon")]
    [SerializeField]
    private GameObject continueIcon;

    [Header("SoundFX")]
    [SerializeField]
    private AudioSource myTextSoundFX;

    public bool IsDialoguePlaying
    {
        get { return isDialoguePlaying; }
    }

    private const string SPEAKER_TAG = "speaker";
    private const string LAYOUT_TAG = "layout";

    private string tagKey;
    private string tagValue;

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

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        isDialoguePlaying = false;
        canPlayerPressE = false;

        dialoguePanel.SetActive(false);
        dialogBGPanel.SetActive(false);

        myOptionValueGO = GameObject.FindGameObjectWithTag(optionValueTag);
        optionValue = myOptionValueGO.GetComponent<OptionValue>();

        //Get all the choices text > Make array as long as choices
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        //Check is Dialogueue is playing
        //If not > return right away
        if (!isDialoguePlaying)
        {
            return;
        }
        canStoryContinue = currentStory.canContinue;

        //BUG: If Player click E when during Choices -> End JSON aka. canStoryContinue = false
        //When there are choices -> Player can't click E
        if (canPlayerPressE)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ContinueStory();
            }
        }

        else
        {
            Debug.Log("E is blocked atm");
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        //Turn off textPanel when entering Dialog
        textPanel.SetActive(false);

        //Init a new story with the chosen inkJSON
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;

        dialoguePanel.SetActive(true);
        dialogBGPanel.SetActive(true);

        //Turn Off RedDot in middle of the screen
        centerDot.SetActive(false);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        isDialoguePlaying = false;

        dialoguePanel.SetActive(false);
        dialogBGPanel.SetActive(false);

        //Set to empty
        dialogueText.text = "";
        Debug.Log("Exit Dialog mode");

        //Call FinishedDialogue Event
        specialLevelChangerHandler.FadeOutUponFinished();
    }

    //Have to make it public so Click BUtton > Instant move to next line
    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //Current displayed sentence = currentStory the next line
            dialogueText.text = currentStory.Continue();

            //Type the sentence out with a Coroutine:
            StartCoroutine(InkleTypeSentence(dialogueText.text));

            //Display choices if there are any
            DisplayChoices();

            //Handle tags
            HandleTags(currentStory.currentTags);
        }

        else
        {
            Debug.Log("Story cant continue and JSON is empty. Dialogue is finished :D");
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        //Loop through the tags
        foreach (string tag in currentTags)
        {
            //parse the tag: seperate > key[0] : value[1]
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag can't be parsed "+ tag);
            }

            //Trim is to clean waste space after Tag
            tagKey = splitTag[0].Trim();
            tagValue = splitTag[1].Trim();

            //Debug.Log("Key_0: " + splitTag[0]);
            //Debug.Log("Value_0: " + splitTag[1]);

            //Handle the tag
            switch (tagKey)
            {
                //First tage will change the speaker name
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                //Second tag will re-position SpeakerFrame through Animation
                case LAYOUT_TAG:
                    speakerPanelAnimator.Play(tagValue);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        

        List<Choice> currentChoices = currentStory.currentChoices;

        //Foolproof
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Not enough choicesUI for inkChoices " + currentStory.currentChoices);
        }

        //Loop for choices
        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            //Make sure choice is active
            //And has ButtonText to InkChoice' text
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;

            index++;
            canPlayerPressE = false;
        }

        //Go through remaining choices
        for (int i = index; i < choices.Length ; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(ResetSelectedChoice());
        Debug.Log("Choices!");
    }

    private IEnumerator ResetSelectedChoice()
    {
        //Need to clear first
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
    }

    public void MakeChoice(int choiceIndex)
    {
        //If this Button is selected > ONLY THEN can it be chosen
        //Atm this if-statement only called once > Player can't change selected choice
        if (EventSystem.current.currentSelectedGameObject == choices[choiceIndex].gameObject)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);

            Debug.Log("If statement is true with " + EventSystem.current.currentSelectedGameObject.name);
        }

        else
        {
            Debug.Log("This button is not selected");
            return;
        }
        
    }

    IEnumerator InkleTypeSentence (string sentence)
    {
        //Have Dialog text empty first
        dialogueText.text = "";

        //Save all the letters in an array
        foreach (char letter in sentence.ToCharArray())
        {
            //The the array pop out each letter at a time
            dialogueText.text += letter;

            myTextSoundFX.Play();

            //Between each pop of letters we wait for X second(s)
            yield return new WaitForSecondsRealtime(optionValue.FlowTextDelay);
        }

        yield return new WaitForSecondsRealtime(optionValue.CloseTextDelay);
        continueIcon.SetActive(true);
    }

    public void ResetPlayerCanClickE()
    {
        //This will reset the bool after the choice
        canPlayerPressE = true;
    }
}
