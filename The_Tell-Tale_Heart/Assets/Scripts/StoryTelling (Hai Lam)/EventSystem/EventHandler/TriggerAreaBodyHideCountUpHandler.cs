using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaBodyHideCountUpHandler : MonoBehaviour
{
    [SerializeField]
    private string bodyPartTag = "BodyPart";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bodyPartTag))
        {
            CounterEventManager.BodyPartsHideCountUp();
        }
    }
}
