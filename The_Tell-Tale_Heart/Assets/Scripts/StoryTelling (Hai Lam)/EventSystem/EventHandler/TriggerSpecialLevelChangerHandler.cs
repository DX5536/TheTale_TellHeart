using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpecialLevelChangerHandler : MonoBehaviour
{
    public void FadeOutUponFinished()
    {
        PolicemanEventManager.FinishedDialogues();
    }
}