using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnusableObjects : MonoBehaviour
{
    [SerializeField]
    GameEvent _lookAtObject;


    private void OnMouseDown()
    {
        _lookAtObject.Invoke();
    }
}
