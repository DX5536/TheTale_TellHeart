using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangerActivateAtStart : MonoBehaviour
{
    [Header("Make sure the FadeIn and FadeOut Animation always there")]
    [SerializeField]
    private GameObject levelChanger;

    // Start is called before the first frame update
    void Start()
    {

        //If LevelChanger not active at Start > Set active
        if (!levelChanger.activeSelf)
        {
            levelChanger.SetActive(true);
            Animator myLevelChanger = levelChanger.GetComponent<Animator>();
        }
        else
        {
            return;
        }
    }
}
