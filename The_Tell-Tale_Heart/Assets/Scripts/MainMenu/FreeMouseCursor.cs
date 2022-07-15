using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMouseCursor : MonoBehaviour
{

    // Unlock the fixed mouse cursor when on non-game scene
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            UnlockCursor();
        }

        //else lock again
        else
        {
            //LockCursorToMidScreen();
        }

    }

    public void LockCursorToMidScreen()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true; //see cursor
    }
}
