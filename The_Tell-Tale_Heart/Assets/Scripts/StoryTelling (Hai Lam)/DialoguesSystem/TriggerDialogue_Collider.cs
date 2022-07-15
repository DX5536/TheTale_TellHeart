using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue_Collider : MonoBehaviour
{
    [Header("Visual Cue to start Dialogue")]
    [SerializeField]
    private GameObject visualCue;

    [SerializeField]
    private string playerTag = "Player";

    [Header("INK JSON")]
    [SerializeField]
    private TextAsset inkJSON;

    private bool isPlayerInRange;

    private void Awake()
    {
        visualCue.SetActive(false);
        isPlayerInRange = false;
    }

    private void Update()
    {
        if (isPlayerInRange && !DialogueManager.GetInstance().IsDialoguePlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                DialogueManager.GetInstance().EnterDialogueMode (inkJSON);
            }
        }

        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            isPlayerInRange = false;
        }
    }
}
