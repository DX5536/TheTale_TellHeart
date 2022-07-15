using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHeart : MonoBehaviour
{
    [SerializeField]
    GameEvent _hideHeart;

    [SerializeField]
    GameEvent _triedLimb;

    [SerializeField]
    private PlayerEvents playerEvents;

 

    private bool _hide;

    private void OnMouseDown()
    {
        if (playerEvents.heartUsed == true)
        {
            if (_hide == false)
            {
                HidingHeart();

            }
        }
        else
        {
            _triedLimb.Invoke();
        }

    }

    void HidingHeart()
    {
        Debug.Log("hide the Heart");
        _hideHeart.Invoke();
        playerEvents.triggerEnding = true;
        _hide = true;



        Destroy(gameObject);
        Destroy(GameObject.FindWithTag("Heart"));
    }


}
