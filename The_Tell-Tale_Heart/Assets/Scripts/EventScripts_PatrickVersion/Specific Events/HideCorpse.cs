using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCorpse : MonoBehaviour
{
    [SerializeField]
    GameEvent _hideLimb;

    [SerializeField]
    GameEvent _triedHeart;
   
    [SerializeField]
    private PlayerEvents playerEvents;

    

    private bool _hide;

    private void OnMouseDown()
    {
        if (playerEvents.limbUsed == true)
        {
            if (_hide == false)
            {
                HidingLimb();

            }
        }
        else
        {
            _triedHeart.Invoke();
        }
        
    }

    void HidingLimb()
    {
        Debug.Log("hide the limb");
        _hideLimb.Invoke();
        _hide = true;

        

        Destroy(gameObject);
        Destroy(GameObject.FindWithTag("Limbs"));
    }

    
}
