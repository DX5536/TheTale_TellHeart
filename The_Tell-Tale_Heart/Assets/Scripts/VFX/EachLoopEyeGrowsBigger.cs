using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EachLoopEyeGrowsBigger : MonoBehaviour
{
    private EachLoopEyeGrowsBigger instance;

    [SerializeField]
    private GameObject eye;

    [Header("How long is the wait for next loop")]
    [SerializeField]
    private int loopDelay;

    [Header("How long is the growth period")]
    [SerializeField]
    private int loopDuration;

    [Header("How large is the growth")]
    [SerializeField]
    private float scaleValue;

    private void Awake()
    {
        //Create an instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        else if (instance != null)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        StartCoroutine(EyeLoop(loopDuration));
    }

    private IEnumerator EyeLoop(int loopCount)
    {
        for (int i = 0; i < loopCount; i++)
        {
            eye.transform.localScale += Vector3.one * scaleValue;
            yield return new WaitForSeconds(loopDelay);

            Debug.Log("Loop is at " + i);
        }
        
    }
}
