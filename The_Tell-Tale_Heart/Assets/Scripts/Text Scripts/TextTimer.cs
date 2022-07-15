using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    [SerializeField]
    private float textTime = 10.0f;

    [SerializeField]
    private GameObject TextObject;

    private bool timerRunning = false;

    public void StartTimer()
    {
        timerRunning = true;

        Debug.Log("timer should start");

    }

    private void timerEnded()
    {
        Debug.Log("timer should end");
        Destroy(TextObject);
    }

    private void Update()
    {
        if(timerRunning == true)
        {
            textTime -= Time.deltaTime;
        }

        if (textTime <= 0.0f)
        {
            Debug.Log("ending timer");
            timerEnded();
            timerRunning = false;
        }

    }

}
