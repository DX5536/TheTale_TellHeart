using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGlowingEyesBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject eyesPrefab;

    [SerializeField]
    private GameObject spawnEyeLocation;

    [Header("The ID of when Ray hit OldMan")]
    [SerializeField]
    private int storyID;

    private void OnEnable()
    {
        StoryEventManager.onMurderEvent += ActivateEye;
    }

    private void OnDisable()
    {
        StoryEventManager.onMurderEvent -= ActivateEye;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            //Quick Debug
            //ActivateEye();
        }
    }

    public void ActivateEye(int storyID)
    {
        if (storyID == this.storyID)
        {
            Instantiate(eyesPrefab , spawnEyeLocation.transform);
            Debug.Log("Spawn eye at " + eyesPrefab.transform.name);

            //After Instantiate once > UnSub from event
            StoryEventManager.onMurderEvent -= ActivateEye;
        }
    }
}
