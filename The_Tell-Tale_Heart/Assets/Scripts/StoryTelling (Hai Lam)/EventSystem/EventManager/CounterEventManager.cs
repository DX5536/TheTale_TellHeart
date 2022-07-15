using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CounterEventManager : MonoBehaviour
{
    //Event for counting how many bodyparts are hidden
    public static event Action onBodyPartsHideCountUp;
    public static void BodyPartsHideCountUp()
    {
        if (onBodyPartsHideCountUp != null)
        {
            onBodyPartsHideCountUp();
        }
    }
}
