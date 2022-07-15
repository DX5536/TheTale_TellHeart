using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutCorpse : MonoBehaviour
{
    [SerializeField]
    GameEvent _cutCorpse;

    [SerializeField]
    GameEvent _getSaw;

    [SerializeField]
    private PlayerEvents playerEvents;

    [SerializeField]
    private GameObject corpse;

    private bool _cut;

    private void OnMouseDown()
    {
        if(playerEvents.sawUsed == true)
        {
            if (_cut == false)
            {
                Cutting();
            }
        }
        else if(playerEvents.sawUsed != true)
        {
            _getSaw.Invoke();
        }
        
    }
    
    void Cutting()
    {
        Debug.Log("cut the corpse");
        _cutCorpse.Invoke();
        _cut = true;

        GameObject.FindWithTag("Limbs").transform.localPosition = corpse.transform.localPosition;

        GameObject.FindWithTag("Heart").transform.localPosition = corpse.transform.localPosition;

        Destroy(gameObject);
        Destroy(GameObject.FindWithTag("Saw"));
    }

    

}
