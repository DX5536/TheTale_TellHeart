using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplicatedOriginalMaterial : MonoBehaviour
{
    [SerializeField]
    private GameObject[] currentChildrenObjects;

    [SerializeField]
    private Renderer[] childObjectOwnRenderers;

    [SerializeField]
    private Material[] ogChildMaterials;

    public Renderer[] ChildObjectOwnRenderers
    {
        get { return childObjectOwnRenderers; }
        set { childObjectOwnRenderers = value;}
    }

    public Material[] OgChildMaterials
    {
        get { return ogChildMaterials; }
        set { ogChildMaterials = value; }
    }


    //GameObject grab their own current Material and save it in ogMaterial
    private void Start()
    {
        //Go through all the children there
        for (int h = 0; currentChildrenObjects.Length > h; h++)
        {
            //And save all the children (as GO) of this GO in an array -> GameObject[]
            currentChildrenObjects[h] = transform.GetChild(h).gameObject;
        }

        //Now go through the first array of saved children GO
        for (int i = 0 ; currentChildrenObjects.Length > i ; i++)
        {
            //Get the renderer comp of each Children and save it in 2nd array -> Renderer[]
            childObjectOwnRenderers[i] = currentChildrenObjects[i].GetComponentInChildren<Renderer>();

            //Go through 2nd array and save it in 3rd Array -> Materials[]
            ogChildMaterials[i] = childObjectOwnRenderers[i].material;
            
        }
 
    }
}
